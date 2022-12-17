VAR StoryTittle = ""
VAR StoryQuestion = "The masseuse enters and says I'm not supposed to take off ALL my clothes. What do I do?"
VAR StoryCategory = "Cyan"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 50

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0
VAR Character0EnduranceCh = 0

I go to get a massage at a place and take off my clothes once I'm in the room.
The masseuse enters and says I'm not supposed to take off ALL my clothes. What do I do?
* [Just say I thought this was normal.]
    -> res1
* [Apologize and put my clothes back on.]
    -> res2
* [Apologize, ask to use the bathroom and climb out the window.]
    -> res3

=== res1 === 
The masseuse thinks I'm a pervert and gets the manager and I get thrown out.
~TextForLog = "They actually physically throw me out once I get my clothes back on and I am so embarrassed. I wasn't trying to do anything weird I just thought that was normal!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
The masseuse forgives me and gives me the massage and it helps me out a lot.
~TextForLog = "Well, I felt awkward at first but after telling the masseuse it was an honest mistake and apologizing, things were fine. I spent the $50 and got a great massage that I had desperately been needing. I may go back again. I'll keep my clothes on next time though."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-50%"
* [Ok]
-> END

=== res3 === 
After apologizing I use the bathroom and change and run off.
~TextForLog = "I couldn't bear to stay there after such an embarrassing event. I ran off after I got my clothes back on but I later realized my wallet must have fallen out. So, now I am out one wallet and all $150 I had in there. But there is no way I am ever going back to that place."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-150%"
* [Ok]
-> END
