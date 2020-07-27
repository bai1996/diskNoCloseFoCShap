<h1 align="center">
   DNC   
</h1>
-向指定路径写入文件后删除文件，以保证硬盘驱动器（针对移动硬盘,尤其是带节电的）不关闭
-特别是当游戏放在移动硬盘里，游戏载入到内存后，硬盘不会读取、写入，等开启了节电再次读取游戏数据的时候会造成音画不同步，如果出现此问题，那么开启此工具会解决此问题

#### 使用说明
如果无法运行，请安装[.NET Framework 4.0 ] Runtime版
下载地址：http://go.microsoft.com/fwlink/?LinkID=287120

如果使用默认的地址，直接运行dnc.exe即可，默认地址是"M:\temp\temp.txt"，如果你有M盘的话

参数
	dnc [-h | /h | -help | /help ]:打开帮助，
	dnc [filePath] [fileName] [runRate],注意参数间使用空格分隔
	filePath:文件夹路径(如：Z:\temp\)
	fileName:文件名：(如：temp.txt)
	runRate:执行频率(单位：秒)
`示例`

```shell

rem 如果需要自定义地址，则需要输入一个参数，注意：需要符合规范的地址结尾需要有\
dnc.exe Z:\temp\

rem 如果需要自定义地址和文件名，则需要输入两个参数，
dnc.exe Z:\temp\ temp.txt

rem 如果需要自定义地址和文件名，并自定义执行频率，则需要输入三个参数，第三参数单位为秒
dnc.exe Z:\temp\ temp.txt 1

```