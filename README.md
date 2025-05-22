# DnD_manager
D&amp;D Manager built with C# ASP.NET and Bootstrap

Basic database functionality implemented using MySql.  No creating new characters or editing existing characters, but copying and deleting are implemented.  Starting with a character manager feature + user accounts.  Eventually want to expand to manage NPCs and Monsters, and perhaps class, race, and spell databases users can browse and lookup info in.  Longterm plan to implement features useful to GMs running and managing games.

Originally planned to use MongoDb, but document database didn't serve the functionality necessary for the web app, so I switched to relational database.  Still open to using MongoDB to develop an API down the line for integrating with outside services such as Discord Bots that can fetch character data.