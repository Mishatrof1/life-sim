VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Cyan"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 50

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0

I'm about to get a massage and I realize I have really bad gas.
What do I do?
* [Hold it in]
    -> res1
* [Ask for a moment alone before the massage to secretly relieve myself.]
    -> res2

=== res1 === 
The gas is so uncomfortable that I can't enjoy the massage and later get home and feel sick.
~TextForLog = "I spent $50 for a massage that I couldn't enjoy and all the straining and holding it in, I think I injured something. I get home and feel sick to my stomach. Because you're not supposed to hold it in that long, I'm pretty sure!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-50%"
* [Ok]
-> END

=== res2 === 
The masseuse leaves and as I am relieving myself the masseuse re-enters and freaks out.
~TextForLog = "The masseuse re-entered and hears me right in the middle of everything. The masseuse freaks out and they throw me out of the place. Which is a bummer. But I feel better. And maybe it was a sign for me to save my money and not waste it on a massage."
~Character0HappinessCh = "%ValueRef:0:-%"
* [Ok]
-> END
