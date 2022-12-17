VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR Character0WealthCh = 0
VAR Character0HealthCh = 0
VAR Character0AppearanceCh = 0

I'm about to get ready for my shift at work when I find out our shower is broken and I need to shower still!
What should I do?
* [Just go into work anyway.]
    -> res1
* [Call out sick]
    -> res2
* [Take a "deodorant shower" and go into work.]
    -> res3
* [Jump in the pool and try to bathe in there.]
    -> res4

=== res1 === 
I get to work early but no one wants to work near me because I smell. But I get a lot of work done.
~TextForLog = "No one wants to work anywhere near me because I stink and they're all making fun of me. Oh, I am so embarrassed and depressed now. But I got to work early since I skipped a shower and since no one worked anywhere near me I ended up being very productive at work. If that makes it worth it... not sure it does."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~Character0WealthCh = "%50%"
* [Ok]
-> END

=== res2 === 
I call out sick, stay home and watch movies all day.
~TextForLog = "I wasn't about to go into work stinking to High Heavens. I call out sick and just stay home and watch movies all day. It was actually really nice to just have a day off, but I probably ate too much junk food in the process."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
The deodorant masks the fact I didn't shower pretty well but I am paranoid all shift someone will start to smell me.
~TextForLog = "No one seemed to notice I didn't shower and the deodorant does the trick. But all shift I'm so nervous, I keep going to the bathroom to use the sink and try to clean myself little by little. I end up being so unproductive at work, I hardly get any work done at all. I also leave work early before I start stinking too much."
~Character0WealthCh = "%30%"
* [Ok]
-> END

=== res4 === 
The pool definitely masks the fact I didn't shower and the chlorine gives me a cool little hairdo.
~TextForLog = "The pool did the trick. Who knew?! And in addition to masking the fact that I didn't shower, the chlorine from the pool did something cool to my hair and everyone is asking about my new look and if I got a haircut and being so complimenting. Maybe I shower in the pool before every shift now!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0AppearanceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~Character0WealthCh = "%50%"
* [Ok]
-> END
