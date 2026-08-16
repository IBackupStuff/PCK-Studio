7.1.2
=====

Changes:
-Importing bedrock skin models will no longer flip UVs automatically
-Importing bedrock skin models will no longer set OFFSET parameters

Bug Fixes:
-Fixed a bug where the GRF Editor would hide the entire program when closed
-Fixed a bug where "BODYARMOR" boxes would become "BODY" boxes when importing Bedrock skin models
-Made a temporary fix for a bug where 5.0 BlockBench skin models would not import properly. Full support is planned.

7.1.1
=====

Bug Fixes:
-Fixed cancelled MessageBox erroneously stating "Node not extracted" while using the Export Skin Icon tool.
-Skin icons can no longer be exported for skins with abnormal resolutions.
-Skin paper dolls can no longer be created for skins with abnormal resolutions. A default skin icon will be returned instead.
-Fix crash for paper dolls generated from skin textures smaller than the base resolution skin size
-Fix crash for paper dolls generated from skins with boxes placed outside of the base resolution skin canvas
-Added the changelogs for 7.1 and 7.1.1 to the main menu

7.1 ("The Skin Update")
=======================

Additions:
-Added support for all Skin box formats (known in game data as XMLVERSION).
-Added "Set Box Version" feature for SkinData files (such as Skins.pck).
-Added support for Armor Masking for Skins in several editors.
-Added the Box Editor to the Skin Editor.
-Added the ability to export GRF files as JSON.
-Added Skin Adjustments Editor for editing ANIM and GAME_FLAGS values.
-Added Skin Adjustments Editor to the Skin Editor.
-Added setting to disable Cape rendering in the Skin Editor.
-Added special skin icons for slim and classic skins.
-Added custom skin and cape icons.
-Added settings to disable custom skin and cape icons.
-Added feature to change the Skin Box Version of the working PCK.
-Added feature to export custom skin and cape icons.
-Added tools to display in the Skin Editor for tool offsets.
-Added "Add OFFSET Parameter" tool to the Parameter tree.
-Added buttons representing each armor type in the Skin Editor that will mask boxes appropriately.
-Added several checks for saving a working PCK with a present SkinData file (such as Skins.pck) to help the user prevent crashes.
-Added "Set Pack ID" tool under the "PCK" tab.
-Added "Extract PCK Contents" tool under the "PCK" tab to extract the contents of the working PCK to a given directory.
-Added tool to convert SkinData files (such as Skins.pck) into a folder and applying the SkinData file's Skin Box Version to the working PCK.
-Added bulk edit tool to the Audio Editor.
-Added the ability to drag and drop skin nodes to change the order of skins
-Added move up/down tools for rearranging skin nodes
-Added PCK Skin Model Version 2 for the Skin Editor with support for all 22 box types, GAME_FLAGS, and full armor masking.
-Added Texture Pack Info Editor for TexturePackInfo files (such as x16Info.pck and x32Info.pck).

Changes:
-Renamed "Edit" tab to "PCK" for tools relating to the working PCK
-The PCK tab is now only visible when editing a PCK
-Changed "Save as Xbox One/PS4/Switch/Vita PCK" checkbox to "Save as Xbox 360/PS3/Wii U PCK" instead as there are less platforms that use this endianness format than not.
-Changing the "Save as Xbox 360/PS3/Wii U PCK" checkbox will now set all child PCKs within the working PCK to the desired endianness.
-Folders now appear on top of files
-PCK Properties have been renamed to Parameters to match the game's technical terms.
-"0" Files will no longer appear
-Removed and consolidated "Add Texture", "Add File", "Import Skin", "Import Extracted Skins Folder" tools into "Import File" and "Import Folder" tools.
-Drag and dropping files into the program now shares code with the "Import Folder" tool for consistency.
-Imported Skins now add missing LOC entries to the working PCK's LOC file if one is present.
-Audio Editor has been simplified to work with only text entries for track entries
-Audio Editor now allows for editing an entry when double clicking
-Audio Editor now uses the game's technical terminology used for Audio Data files
-Box Editor has become a form rather than an editor and has been added to the Skin Editor.
-Removed ANIM Editor in favor of the new Skin Adjustments Editor.
-Editing an ANIM or GAME_FLAGS editor will open the Skin Adjustments Editor and allow the modification of both values simultaneously.
-Cape now rendered in the correct spot in the Skin Editor.
-Boxes now display dimensions next to the type in the box list.
-Skin and cape textures will now be checked for validity when imported.
-The user can no longer add offsets if there are no more available offsets
-The "Generate MipMap" tool has been simplified to only generate the given level
-Boxes with armor flags can now be hidden when wearing armor in the Skin Editor
-Skin files are now checked to see if they are designed for Skin Box versions that the working PCK is not set to.
-Duplicate OFFSET entries are now ignored entirely throughout the program.
-Tool and armor offsets now display accurately to in game rendering in the Skin Editor.
-Adjusted armor inflation rendering values in the Skin Editor to be more accurate to in game rendering.
-Removed "Fix Skin Decimals" tool as the problem it seeked to solve has become niche and fixed in other editors.
-PCK parameters now accept " " as the delimiter globally across the program instead of ":"
-Saving a PCK now displays the working PCK's name in the pop up message for better clarity.
-Hidden unused Quick Change tool
-Skins.pck is no longer made by default when making a texture pack or mash-up pack
-Removed option to make Skins.pck when making a texture pack or mash-up pack
-Custom Skin Editor now displays localized keys in place of the display name by default and will fall back on the display name and finally the localization key if missing.

Bug Fixes:
-Fixed selected nodes no longer being selected after the main form's tree was rebuilt
-Fixed boxes under the maximum allowed box arguments wouldn't parse correctly.
-Fixed a crash when selecting image assets with invalid image data.
-Fixed entity texture assets displaying "Edit Texture Atlas" button in the main form.
-Fixed Skin Editor not displaying Armor Box types.
-Fixed Skin Editor not saving properly when using the Auto Save feature.
-Fixed Little Endian PCKs (Xbox One/PS4/Switch/PSVita) not saving properly.
-Fixed first indexed box not saving changes in Custom Skin Editor.
-Fixed inflation input not allowing for negative values in Box Editor.
-Fixed a crash when replacing a tile group with images smaller than expected in the Atlas Editor.
-Fixed the platform checkbox in the upper right corner of the main form not being set on open
-Fixed custom picture button controls now displaying properly in all contexts
-Fix for the Audio Editor not using the platform checkbox and therefore failing to open.
-Fix for being able to drop a asset file into another asset file
-Fix for a crash when image asset file contents were empty in several contexts
-Fix for DISPLAYNAME being set even if empty after saving in the Skin Editor

7.0
===

-Added .3dst (3DS Texture) support  
-Semi-added Sub-Pck editing  
-Add an edit all properties tool item  
-Skin Preview has been improved  
-Added Pack Icon Injection into .arc file  
-Improved COL Editor  
-Massive codebase overhaul and optimization lead by miku-666 (aka NessieHax)!!!  
-Some UI redesigned by yaboiFoxx  
-Improved the changelog!  
-New icons for each of the file types, with unique image icons for skin, texture, and cape files  
-Added the ability to create Texture and Mash-Up packs  
-Added a feature to see stats about any given file, including file type  
-Added a feature set file types for any given file  
-Added partial editing support for PCKs within other PCKS (MAJOR WIP)  
-Improved LCE -> Bedrock Skin Pack conversion  
-Improved Create Skin function and menu  
-Added Skin ANIM Editor  
-Added GRF Editor and overall support for GRF files  
-Delete tool now works with subfolders  
-Improved Skin Viewer  
-Added support to export Java Edition animations from the Animation Editor  
-Added BINKA and WAV drag and drop support in the Music Editor  
-Added a feature to verify files in the Music Editor  
-Added a feature to delete all unused songs in the Music Editor  
-Added a feature to locate and open the pack's Data folder in the Music Editor  
-Fixed way too many bugs to list  
  
6.5  
===  
-Audio.pck Editor is now the Music Editor with plenty of new features  
-The Animation Editor now plays animations more accurately  
-Added MipMap support to the Animation Editor  
-Added some text to display the common name of the animation that you're working with  
-Fixed several incorrect internal names for the change tile list  
-Removed Barrier (Item) from the Change Tile list  
-Clicking "Cancel" in the Change Tile dialog will no longer overwrite the original tile's name with nothing.  
-Stained Glass tiles are now displayed as "<color> Stained Glass" instead of "<color> Glass" in the Change Tile list  
  
6.4  
===  
-Added the Animation and Audio.pck Editors  
-Added Water Color support to the Color Editor  
-LOC Editor now properly supports UTF-8  
-"Move Up" and "Move Down" functions finally work properly and with folders  
-Replaced the "Create Animated Texture" function with the new Animation Editor  
-Added JSON Importer to Model Generator  
-Rename/Clone functionality added  
-Added a Drag and Drop feature to the main file tree  
-Rename function now properly works with folders  
-Fixed the Edit LOC button from appearing on folders and non files  
-Fixed Add Display ID in the LOC Editor  
-Added a Rename Display ID in the LOC Editor  
   
6.3  
===  
-Fixed Unathorized server access  
   
6.2  
===  
-smaller monitors now supported  
   
6.1  
===  
-Added PSVita/PS4 PCK Support for PCK Center  
   
6.0  
===  
-Moved to new domain  
-Fixed Discord RPC Focusing  
-Fixed offline server breaking PCK Studio  
   
5.9  
===  
-Turned off developer mode  
   
5.8  
===  
-Fixed Issue extracting Skins  
   
5.7  
===  
-Added texture converter  
-Added New Icon  
   
5.6  
===  
-Fixed WiiU Skin Installer  
-Added COL Editor  
   
5.5  
===  
-Added support for PS4/PSVita Packs  
   
5.4  
===  
-Fixed Generated model not showing up  
-Fixed "view skin" button showing up for custom models  
   
5.3  
===  
-Added localized changelogs  
-Added 3D skin viewer  
   
5.2  
===  
-Changed 'Minekampf' internal namespace to 'PckStudio'  
-Added contingency server in event of domain downage  
-Tweaked PCK File Processing  
-Added discord server link and dialogue  
-Added Discord RPC(RichPresenceClient)  
   
5.1  
===  
-Removed unused code(exe slightly lighter)
   
5.0  
===  
-Fixed PCKCenter 'Out of memory' exception  
-Changed String-based versioning to Float-based  
  
4.9  
===  
-Fixed error updating studio [May require re-download]  
  
4.8  
===  
-Fixed Error when starting PCK Center  
  
4.7  
===  
-Revamped website structure  
-new api for PCK Studio [starting this update, only the update feature will be avaliable to older versions]  
  
4.6  
===  
-Added Password Hash method  
-Added 'Add Password' button  
  
4.5  
===  
-Fixed bug opening template PCKs  
-Fixed bug saving PCKs  
  
3.7  
===  
-Project picked up and restored by PhoenixARC  
  
3.6  
===  
-Added Installation options to PCK Center Collection open dialog  
-Added Wii U Perma Installer  
-Fixed more bugs  
  
3.5b  
====  
-Fixed minor bedrock conversion bug  
  
3.5a  
====  
-Model generator bugs fixed  
  
3.5  
===  
-Revamped resizable Main and Model Generator forms  
  
3.4  
===  
-Fully polished MOST of the model generator  
-"Convert to bedrock" now only makes the mcpack  
-Fixed a few things  
  
3.3e  
====  
-Fixed Model Generator throwing error when creating new part  
  
3.3d  
====  
-Fixed Model Generator crashing when minimized  
-Fixed more bugs  
  
2.9c  
====  
-Fixed some minor bugs

2.8b  
====  
-Fixed a few bugs from 2.8  
  
2.8  
===  
-Advanced PCK pck data stucture view  
-Node rearrangement  
-Armor management in Model Generator  
-Fixed several display bugs  
-Added auto LOC detection  
-Added auto PCK skin structuring  
-Folder management  
-Better error handling  
-Image size display  
-Fixed cape typing  
-Organized context menus  
-Added more icons to context menu  
  
2.7  
===  
-Minor UI Fixes  
  
2.4
===
-Model Generator  
-Few UI Improvements  
  
2.3b
====
-Rebranded Minekampf as PCK Studio

2.3  
===
-Fully Fixed Cape Adding  
-Few UI Improvements