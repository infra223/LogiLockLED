// requires Windows 7 Service Pack 1, Windows 8.1, Windows Server 2008 R2 SP1, Windows Server 2012, Windows Server 2012 R2
// express setup (downloads and installs the components depending on your OS) if you want to deploy it locally download the full installer on website below
// https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net481-offline-installer

[CustomMessages]
dotnetfx48_title=.NET Framework 4.8.1

dotnetfx48_size=59 MB

[Code]
const
	dotnetfx48_url = 'https://go.microsoft.com/fwlink/?LinkId=2203304';

procedure dotnetfx48(minVersion: Integer);
begin
	if (dotnetfxspversion(NetFx4x, '') < minVersion) then
		AddProduct('dotnetfx48.exe',
			'/lcid ' + CustomMessage('lcid') + ' /passive /norestart',
			CustomMessage('dotnetfx48_title'),
			CustomMessage('dotnetfx48_size'),
			dotnetfx48_url,
			false, false, false);
end;
