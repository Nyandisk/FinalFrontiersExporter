# FinalFrontiersExporter

A simple KSP plugin that exports the Final Frontiers Hall of Fame ribbons into a very basic HTML file.

## How to use

- Go to the Github releases tab and download the zip
- Unzip it, and move the folder into GameData
- Folder structure should be: `GameData/FinalFrontiersExporter/Plugins`
- While in the space centre, press `Ctrl + F8`

The exported HTML file will be in your base KSP directory, for example: `C:\Program Files (x86)\Steam\steamapps\common\Kerbal Space Program\ribbons.html`

## Building it yourself

- Clone the repo
- If needed, edit the KSP base directory property inside of the `Directory.Build.props` file to match your situation.
- Build as Release
- Move the DLL (`./bin/Release/FinalFrontiersExporter.dll`) into `GameData/FinalFrontiersExporter/Plugins/FinalFrontiersExporter.dll`<br> *Note: you probably need to create those folders first*

## Soon™

Better HTML stylization with additional information gathered from the hall of fame.
