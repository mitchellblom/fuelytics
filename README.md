# Fuelytics
### EFC Take-Home Assessment by Mitchell Blom

<hr>

## Steps to install the code
 - Create environment variable in your .zschrc or .bashrc file. EXAMPLE: `export /Users/mitchellblom/workspace/EFC/Fuelytics.db"`
 - Clone from github using `git clone https://github.com/mitchellblom/fuelytics.git`
 - cd into the created directory
 - In terminal execute `dotnet restore`
 - Execute `dotnet ef migrations add initial`
 - Execute `dotnet ef database update`
 - Execute `dotnet run` which will create and populate db file, queryable by a DB browser

## System configuration needed
 - Install your OS's version of DB Browser for SQLite from http://sqlitebrowser.org/

## Link to view corresponding system presentation
https://docs.google.com/presentation/d/1souBZYAEHxWagr9cbc7g8hDCKBTAt0e-IiVilBAonyY/edit?usp=sharing

<hr>

## Visuals

![ERD](https://raw.githubusercontent.com/mitchellblom/fuelytics/master/images/ERD.png)
![System Outline](https://raw.githubusercontent.com/mitchellblom/fuelytics/master/images/SystemOutline.png)
![Regions](https://raw.githubusercontent.com/mitchellblom/fuelytics/master/images/Regions.png)