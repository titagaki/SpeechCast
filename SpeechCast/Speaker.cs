using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCast
{
    public class Speaker
    {
        public SpeechSynthesizer Synthesizer;

        public SynthesizerState State { get; set; } = SynthesizerState.Ready;

        public int Rate { get; set; } = 0;

        public int Volume { get; set; } = 100;

        private static readonly string SAPILocation = "ja-JP";

        private static string BouyomichanVoiceName = "棒読みちゃん";

        private bool useBouyomichan;

        private static Speaker _instance;

        private List<InstalledVoice> InstalledVoices { get; set; } = new List<InstalledVoice>();
        
        private Speaker()
        {
            if (Synthesizer == null)
            {
                Synthesizer = new SpeechSynthesizer {
                    Rate = Rate,
                    Volume = Volume
                };
            }

            if (InstalledVoices == null)
            {
                InstalledVoices = new List<InstalledVoice>();
            }

            // インストール済みのSAPIなボイスを列挙
            foreach (var voice in Synthesizer.GetInstalledVoices(new CultureInfo(SAPILocation)))
            {
                if (voice != null)
                {
                    InstalledVoices.Add(voice);
                }
            }
        }

        public static Speaker Instance {
            get {
                if (_instance == null) {
                    _instance = new Speaker();
                }

                return _instance;
            }
        }

        public IEnumerable<string> GetInstalledVoiceNames()
        {
            foreach (var voice in InstalledVoices)
            {
                yield return voice.VoiceInfo.Name;
            }

            yield return BouyomichanVoiceName;
        }

        public void SelectVoice(string name)
        {
            if (name == BouyomichanVoiceName)
            {
                useBouyomichan = true;
            }
            else
            {
                useBouyomichan = false;
                Synthesizer.SelectVoice(name);
            }
        }

        public async void SpeakAsync(string sentence)
        {
            if (useBouyomichan)
            {
                await Task.Run(() =>
                {
                    if (InstalledVoices.Count > 0) // レス間隔調整用に無音で喋らせる
                    {
                        Synthesizer.SelectVoice(InstalledVoices[0].VoiceInfo.Name);
                        Synthesizer.Rate = 0;
                        Synthesizer.Volume = 0;
                        var prompt = Synthesizer.SpeakAsync(sentence);
                    }

                    sendToBouyomiChan(sentence);
                });
            }
            else
            {
                Synthesizer.Volume = Rate;
                Synthesizer.Volume = Volume;
                var prompt = Synthesizer.SpeakAsync(sentence);
            }
        }

        //public void SpeakAsyncCancelAll()
        //{
        //    Synthesizer.SpeakAsyncCancelAll();
        //    voiceroidNotifyState = SynthesizerState.Ready;
        //}

        private void sendToBouyomiChan(string sentence)
        {
            string host = "127.0.0.1"; // 棒読みちゃんが動いているホスト
            int port = 50001;          // 棒読みちゃんのTCPサーバのポート番号(デフォルト値)

            TcpClient tcpClient;
            try {
                tcpClient = new TcpClient(host, port);
            }
            catch (Exception) {
                Trace.WriteLine("棒読みちゃん接続失敗:" + host + ":" + port);
                return;
            }

            Int16 command = 0x0001;
            Int16 speed = -1;
            Int16 tone = -1;
            Int16 volume = -1;
            Int16 voice = 0;
            byte charCode = 0;
            byte[] message = Encoding.UTF8.GetBytes(sentence);
            Int32 length = message.Length;                  

            using (var stream = tcpClient.GetStream())
            {
                using (var binaryWriter = new BinaryWriter(stream))
                {
                    binaryWriter.Write(command);  // コマンド（ 0:メッセージ読み上げ）
                    binaryWriter.Write(speed);    // 速度    （-1:棒読みちゃん画面上の設定）
                    binaryWriter.Write(tone);     // 音程    （-1:棒読みちゃん画面上の設定）
                    binaryWriter.Write(volume);   // 音量    （-1:棒読みちゃん画面上の設定）
                    binaryWriter.Write(voice);    // 声質    （ 0:棒読みちゃん画面上の設定、1:女性1、2:女性2、3:男性1、4:男性2、5:中性、6:ロボット、7:機械1、8:機械2、10001～:SAPI5）
                    binaryWriter.Write(charCode); // 文字列のbyte配列の文字コード(0:UTF-8, 1:Unicode, 2:Shift-JIS)
                    binaryWriter.Write(length);   // 文字列のbyte配列の長さ
                    binaryWriter.Write(message);  // 文字列のbyte配列
                }
            }
            tcpClient.Close();
        }
    }
}
