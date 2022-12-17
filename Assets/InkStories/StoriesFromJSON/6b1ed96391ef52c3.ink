VAR StoryTittle = ""
VAR StoryQuestion = "This feels like there is a ghost in my bathroom. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 50

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0PopularityCh = 0

I am home alone and in the shower when suddenly all the bathroom cabinets open and all the stuff inside flies out of them.
This feels like there is a ghost in my bathroom. What should I do?
* [Yell out that I am not scared]
    -> res1
* [Command that whoever is there needs to leave]
    -> res2
* [Run!]
    -> res3

=== res1 === 
After I yell this all the soaps and shampoos fall over in the shower and spill everywhere causing me to slip and fall.
~TextForLog = "After I yelled I wasn't scared, the shampoos and soaps fell over and spilled and I immediately slipped on them and fell and hit my head on the faucet. I think I woke up 20 minutes later and was bleeding and had to call 911. I had a bad gash on my head and now I am terrified of my own home! Something is there."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:2:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
After I say this, the lights flicker on and off and I hear a window in the house open and slam shut.
~TextForLog = "Wow, I didn't know if that would work or not... but there was definitely some other being in the house with me. I guess I just needed to talk with the being and be blunt with it. I have read that before, that you just need to tell spirits to leave... and it seemed to work!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I run out of the bathroom and out of my place and it takes me a minute to realize I am naked outside.
~TextForLog = "I was so scared I ran all the way outside with no clothes on and soaking wet with shampoo still in my hair. I realize after a minute or so when I collect my breath and my thoughts, but by that time one of my neighbors has already filmed me and uploaded the video online and now I am famous on the internet... not how I want to be famous."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
* [Ok]
-> END
