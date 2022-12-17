VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0

I'm drinking from the water fountain and some kid runs up and pulls my pants down, but gets my underwear too.
What do I do?
* [Run to the bathroom to pull my pants back up.]
    -> res1
* [Stand there and own it and calmly pull my pants up.]
    -> res2

=== res1 === 
I try to run to the bathroom and trip and fall and look like such an idiot.
~TextForLog = "I'm so embarrassed, I thought I could make it to the bathroom without too many people noticing but tripping and falling on my face with my pants around my ankles makes everything even more obvious and now I am the BUTT of everyone's jokes... literally!"
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0PopularityCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
Acting like it doesn't bother me gives everyone respect for me.
~TextForLog = "I just acted like it wasn't a big deal and in acting like that, it became not a big deal to me. And in doing so, so many kids respected me for just owning it. They were impressed that I wasn't even rattled by the incident. Now, everyone in school is talking about how I'm unshakeable."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
* [Ok]
-> END
