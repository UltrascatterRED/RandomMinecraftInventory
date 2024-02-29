
# Random Minecraft Inventory

	This application uses Anish Shanbhag's Minecraft-API 
	(https://github.com/anish-shanbhag/minecraft-api)  
	to generate a random player inventory of items.

# Encountered Errors

## Difficulty with API data fetching

	I loosely followed a tutorial by IAmTimCorey on YouTube  
	(https://www.youtube.com/watch?v=aWePkE2ReGw) to set up the  
	basic framework to facilitate API GET requests, and at first,  
	I could not get the data I wanted back (as far as I was able  
	to tell by debugging). The issue was that 'itemsTask' 
	(Program.Main, line 11) technically returns a Task<List<Item>>  
	object, rather than the list itself, and I was trying to call  
	Item class methods directly on itemsTask.

### Solution

	I eventually figured out that I could get the Result property  
	out of the Task object, which was the actual data I was trying  
	to retrieve. Resolving this fixed the error.

## Other Errors

	All other errors amounted to common and minor programming  
	mistakes that I fixed in mere minutes each time.