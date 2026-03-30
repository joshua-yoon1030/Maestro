# The Maestro

>**Introducing... The Maestro! Play Slay the Spire 2 as a conductor, hellbent on climbing the spire for revenge. Shock your foes with his new keyword, Resonance, which does damage to all enemies at the end of each turn. Will you orchestrate a deck that can Slay the Spire?**

## Operation Status
> This mod is currently a work in progress, the two most important things I am working on are listed below:
> - Cards, which I have a plan for [on my Notion project page](https://www.notion.so/32d44d9f0ecd80909363fff261c950db?v=32d44d9f0ecd80dead8b000caad6202e&source=copy_link)
> - Art, which I do not have a plan for :( If you enjoy this project and can draw better than me, please let me know.

## Running and Building this Project
> Trivially, this mod requires you to have Slay the Spire 2 to play. As of the early access period, it's only available on Steam.
> 
> This mod also requires [BaseLib](https://github.com/Alchyr/BaseLib-StS2) as a dependency. Make sure you have [BaseLib](https://github.com/Alchyr/BaseLib-StS2) downloaded before you play this mod.
> 1. Go to the [latest release] (https://github.com/joshua-yoon1030/Maestro/releases/) of this mod and download the dll, json, and pck files.
> 2. Navigate to your steam app folder for STS2. You can go through your file explorer, but the fastest way is to go to your steam library for STS2, then settings button -> manage -> browse local files. Click into the mods folder (if you installed Baselib correctly, this folder should already exist) and add the 3 mod files in.
> 3. Running Slay the Spire will now prompt you if you want to turn the mods on. Once you confirm, it will trigger a reset and you can play with mods now.
> 4. Turn mods on and off by going in game, to Settings -> General -> Modding -> Click which ones you want on or off. Requires a reset to take effect.
>    
> Note that the save file locations are different for modded and unmodded gameplay, meaning that playing with mods for the first time will look like your original save was wiped. Don't worry though, turning off all mods and running the game again will restore your original save file.
>

## Technologies Used And Motivations
> This project was based off the Character Template from BaseLib, but other than that everything else was coded by me. This is a primarily C# project, with some Godot that will be needed for asset manipulation probably. Project management handled through Notion, and version control is handled through git/Github.
> 
> Mainly, this project serves as multiple exercises for me:
> - Coding in C# more: I code exclusively in C# for work but it's still good to have practice, and a plus side means I'm very familiar and rarely have coding issues during development. This is also a psuedo way to contribute to open source, since I still need to be coding within the constraints of the original game.
>   Through modding, I get to see how other professional deveopers architecture their stuff, and learn to navigate my way in a larger, relatively unfamiliar codebase. Very similar takeaways to open source, just a tradeoff for less feedback for more internal motivation.
> - Game Design practice: Modding a completely new design into an already existing game is a great way to practice game design with constraints. Creating games from scratch is also great, but is largely open-ended, comes with lots of pitfalls, and is harder to get people to playtest your stuff. I just find that
>   setting some restrictions on yourself before you design really gets my gears turning rather than a completely blank canvas.
> - Personal Challenge: I had a lot of interest in band/orchestra in high school, and I thought it would be cool to try and make 82 cards about music. Harder than I originally thought.
