VAR StoryTittle = ""
VAR StoryQuestion = "I did have plans to play basketball both days. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 15
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "HigherInPosition"
VAR NPC0MinAgeSc = 30
VAR NPC0MaxAgeSc = 60

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0StrengthCh = 0
VAR Character0WealthCh = 0
VAR Character0IntelligenceCh = 0

My boss %FullName:NPC:1% is offering me overtime for Saturday or Sunday this weekend.
I did have plans to play basketball both days. What should I do?
* [Don't work any overtime]
    -> res1
* [Work overtime on Saturday]
    -> res2
* [Work overtime on Sunday]
    -> res3

=== res1 === 
My boss %FullName:NPC:1% actually gets mad at me but I have a great weekend.
~TextForLog = "I don't know why %FullName:NPC:1% even gets mad at me. It's not like I have to work, it's overtime. Oh well. I had a great weekend and got in a lot of basketball."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:1:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I work on Saturday helping my boss %FullName:NPC:1% organize a ton of furniture and boxes and still play basketball Sunday.
~TextForLog = "Working Saturday wasn't too bad, organizing furniture and boxes. A lot of physical labor, but I got paid pretty well for it. And I still got to play basketball on Sunday, so that was great."
~Character0HealthCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0WealthCh = "%75%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I play basketball on Saturday and help my boss organize some spreadsheets on Sunday.
~TextForLog = "I still got to play basketball on Saturday so that's great. And on Sunday my boss %FullName:NPC:1% needed help with the spreadsheets. In fact, %Pron:1:1% had no idea how to do anything with spreadsheets so I had to teach %Pron:1:2%, but I got paid quite well for it!"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%100%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
