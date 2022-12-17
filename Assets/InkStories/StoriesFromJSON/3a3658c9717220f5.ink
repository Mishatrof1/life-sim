VAR StoryTittle = ""
VAR StoryQuestion = "Which team should I gamble on?"
VAR StoryCategory = "Gold"
VAR TextForLog = ""

VAR Character0OccupationSc = "College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 48

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0

I'm trying to decide what game I want to put money on.
Which team should I gamble on?
* [$50 on the Giants to win]
    -> res1
* [$50 on the Jets to win.]
    -> res2
* [$50 on the Cardinals to win.]
    -> res3

=== res1 === 
The Giants lose.
~TextForLog = "The Giants were favored but they still lost. Oh well, there goes $50. I'm not really quite lucky with gambling, am I?"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-50%"
* [Ok]
-> END

=== res2 === 
The Jets win and I make $200!
~TextForLog = "Yes! I just won $200! Lucky me! I don't think the Jets were really favored to win so that was really lucky for me!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%200%"
* [Ok]
-> END

=== res3 === 
The Cardinals win big in a huge upset but before I can cash my ticket out someone jumps me and steals it.
~TextForLog = "I can't believe it! I was about to win a bunch of money and then someone stole my ticket! Not before they bashed my face in and knocked me to the ground though. I am so mad, I must have been talking too loudly about my winning ticket, I think next time I need to shut my mouth when I gamble."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-50%"
* [Ok]
-> END
