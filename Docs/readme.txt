========== SpeechCast ==========

■概要
　SpeechCastは「２ちゃんねる」「jbbs(したらば)」「わいわいkakiko」に書き込まれたレスを読み上げ、
　画面上に字幕のように表示するソフトです。
　PeerCastで配信する際に使用するのを想定しています。

■ライセンス
　フリーソフトです。
　GPLv2ライセンスでソースを公開しています。

　https://github.com/ggslyman/SpeechCast

■サポートOS
　WindowsXP SP3/Windows 7
　（他のOSに関しては作者が動作チェックする環境がないため、非サポートとしています）

■必要なソフト
　SpeechCastを使用するためのソフトです。
　
　・Microsoft .NET Framework 4.5
　・SAPI5.1対応の音声エンジン
　　標準では「Microsoft Sam」という日本語非対応の音声エンジンしかインストールされていないはずです。
　　別途、日本語対応の音声エンジンを入手してください。

■使い方
　(1)SpeechCast.exeをダブルクリックで起動します。

　(2)URLに掲示板のURLを入力します。　例) http://jbbs.livedoor.jp/bbs/read.cgi/game/46310/1226217756/
　  TOPページを入力するとスレ一覧が表示されます。
　
　(3)左上のリストビューにレスの一覧が表示されるので、再生開始したいレスを選択します。
　
　(4)自動更新ボタンを押します。
　　先ほど選択したスレから音声再生が始まります。最後のスレまでいくと、定期的に掲示板を更新して新しい
　　レスがあれば再生します。

　(5)字幕ボタンを押した状態だと字幕が音声再生と同時に表示されます。枠ボタンで表示領域を調整できます。

■設定
　ツールバー右の設定ボタンを押すと各種設定を行うことができます。
　
　詳細は割愛します。
　
　設定は(ユーザホームディレクトリ)/Application Data/SpeechCast以下に記録されます。
　起動しなくなったら上記ディレクトリごと削除してみてください。
　
　
　【読み方についての補足】
　読み方の書式は以下の通りです。
　
　　単語/読み方
　
　もしくは
　
　　単語/読み方/オプション
　
　・単語には正規表現が使えます。
　・オプションは以下の通りです。（.NET Frameworkヘルプより引用）
　　s シングルラインモード：
　　　単一行モードを指定します。\n 以外の任意の文字ではなく、すべての文字と一致するようにピリオド 
　　　(.) の意味を変更します。 
　　m マルチラインモード：
　　　複数行モードを指定します。^ と $ の意味を変更して、文字列全体の先頭と末尾だけでなく任意の行
　　　の先頭と末尾にもそれぞれが一致するようにします。 
　　i 大文字小文字を区別しない：
　　　検索時に大文字と小文字を区別しないことを指定します。 

　【AAモードについての補足】
　
　　指定した条件でAAモードになります。
　　
　　AAモードは通常モードと以下の点が異なります。
　　・字幕の縁の色が緑色。
　　・設定に関係なく字幕が瞬間表示。
　　・枠の大きさに合わせて、フォントが縮小されます。（設定でOFFにすることも可能）
　　・字幕の表示時間が異なります。（デフォルトでは通常モードより長くなります）

■サポート
　Github上および下記の掲示板で行っています。

　slyman.ch避難所
　http://bbs.aristocratism.info/slyman/

■制限事項
　・２ちゃんねる、jbbs、わいわいkakiko、あっとちゃんねるず以外の掲示板には対応していません。

■検討中の機能
　・Webアクセスの非同期化
　・URLパースおよびdatファイル取得の外部ライブラリ化

■更新履歴

　14/03/01 2.0.0 Rev.1
時計表示(字幕に特定文字列を埋め込み)
字幕ワンボタンカウントアップダウン機能(字幕に特定文字列を埋め込み、凸募集向け)
オート次スレオープン機能追加
jbbs.shitaraba.netに対応（よっしーchさん修正済み）
あっとちゃんねるず(http://atchs.jp/)に対応
代替字幕表示機能追加（Janeのようにステータスバーをクリックで字幕入力欄表示、入力欄の外をクリックおよび、Ctrl+Sで反映）
着信音を複数登録可能に修正（複数登録時にはどれか一つをランダム再生）
ターボモード搭載（読み上げタスクにたまった件数が一定以上になった時に、読み上げ速度アップおよび読み上げ間隔短縮）
字幕ウィンドウのタイトルに現在読み込んでいるスレタイトルおよび現在のレス数を表示するように修正
音声読み上げON/OFFボタンの追加
レス着信音ON/OFFボタン追加
レス読込時のクリック音ON/OFFボタン追加
音声読み上げのテストボタンを設定画面の音声タブに追加
字幕の表示位置調整を設定画面に追加
インターネット接続タイムアウト時に字幕が塗りつぶされる場合のオプション、字幕エリアの自動縮小ON/OFFボタンを追加
リロード最短間隔をメカキャス準拠の7000ミリ秒に変更
使いどころのわからなかったフォント色指定の透過色の設定を削除
ReadMeの履歴を降順に整理

　09/10/20 1.0.6
Windows7+Aero環境だと、字幕ウィンドウの下にあるアプリをクリックすることができない不具合を修正
リンクを開くときはデフォルトのブラウザを使用するように変更
レスアンカーのポップアップ位置を調整

　09/06/15 1.0.5
「SpeechCastタイトルを非表示にする」設定を追加(デフォルトオフ)
レスおよびスレッド作成ウインドウに、再生ボタンを追加
レスおよびスレッド作成ウインドウにsageチェックボックスを追加
レスおよびスレッド作成ウインドウの名前およびメールアドレスを保存するように変更
URL(http|ttp)をリンクにするように変更
サポート掲示板に移動するメニューを追加
細かい不具合の修正および改良

　09/05/29 1.0.4
実行ファイルのプラットフォームをx86(32bit)に固定した
レス書き込み成功後のメッセージボックスを出さなくし、代わりにログに流すようにした
レスアンカーのポップアップ表示を実装

　09/05/20 1.0.3
書き込みウィンドウに編集ボタンを追加
あぼ〜ん判定したときは、自動で全レス取得直すように修正

　09/04/27 1.0.2
フォント色設定を追加
字幕の縦書きモードを追加
AAモード時のレス番号を読み上げるオプションを追加（デフォルトON）
レス一覧画面で絞り込みテキストボックスと、「勢い」の列を追加

　09/04/12 1.0.1
2chの書き込みの仕様変更に対応
細かい不具合の修正

　09/04/11 1.0.0
バージョン番号更新
細かい不具合の修正

　09/04/06 1.0.0RC1
新着レスがあったとき、サウンドを鳴らすオプションを追加。
クリップボードからURLを貼り付けて開くボタンを追加。
設定のテキストボックスの横に編集ボタンを追加。
読み上げのボリューム設定UIをTrackBarに変更。
バージョン情報ダイアログを設定画面から独立させた。
AAモード時の固定読み上げ文字列設定を追加（デフォルトでは「アスキーアート」）

　09/03/31  β5
GZip圧縮がONになっていると、(416) Requested Range Not Satisfiableエラーが出る不具合を修正。
AAモードの字幕の縁の色を、暗くした。
1000(1001)番目のレスがAAモードだと、警告メッセージもAAモードになってしまう不具合を修正。

　09/03/30  β4
通信→GZip圧縮項目を追加。(デフォルトON)
通信→インターネットオプションで設定したプロキシを使用するオプションを追加。(デフォルトON)
字幕を瞬間表示するオプションを追加。(デフォルトOFF)
レス画面の更新を高速化
ステータスバーに通信状況などを表示するようにした。
字幕表示状態をコンフィグに保存するように変更。
ツールバーをアイコン表示変更。
読み上げ関連のボタンをツールバーに追加。
ブラウザで開くボタンを追加。
プログラムアイコンをちゃんとしたものに変更。
レス1000越えのメッセージの警告メッセージ間隔を設定に関係なく20秒に変更。
AAモードを実装。
コンフィグファイルが無い場合、読み方およびAAモードになる条件のでデフォルト文字列を設定するように変更。

　09/03/18  β3
読み上げ時に例外が発生する不具合を修正。

　09/03/18  β2
ブックマーク機能を実装。
読み方の正規表現のオプションを指定できるように書式を追加。
字幕ウィンドウのタイトル部分を小さくした。
次のレス／前のレスなどを読み上げる機能を追加。
読み上げをやめる機能を追加。
クリップボードの内容を読み上げる機能を追加。
文字数制限を、読み方変換したあとに適用するように変更。
その他細かい修正および機能追加。

　09/03/01  β1
2ch/わいわいkakikoで差分更新(Rangeヘッダー)に対応。
設定画面を出しているときは、自動更新しないように修正。
スレッド一覧機能を実装。
コンフィグの保存パスのスペルが間違っていたのを修正。
レス書き込みおよびスレッド作成機能を実装。
フォントの設定のプレビューを追加。

　09/02/12  α5
字幕ウィンドウの座標がマイナス値の時、移動およびリサイズが正常に行えない不具合を修正。
URL入力のテキストボックスの横幅を少し小さくした。

　09/02/09  α4
有効なURLが入力されていない状態で、自動更新を押すと「サポートしていないURLです」というメッセージボックスが無限に出現する不具合を修正。

　09/02/08  α3
URL http://***.2ch.net/に対応
コマンドラインからURL指定すると、そのURLを開くようにした
追加レスがなくてもリストビューとレス表示画面を更新したのをやめた

　09/01/19  α2
URL http://yy.***.com/に対応

　09/01/12  α1
初公開

