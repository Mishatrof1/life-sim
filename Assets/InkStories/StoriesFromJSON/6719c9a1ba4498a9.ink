VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool:College"
VAR Character0MinAgeSc = 10
VAR Character0MaxAgeSc = 22
VAR NPC0RelativesSc = "Sibling"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0StrengthCh = 0
VAR NPC0SympathyCh = 0

Me and %FullName:NPC:1% are going to play football with his friends and we are trying to decide on how to play.
What should we do?
* [Play touch football.]
    -> res1
* [Play tackle football.]
    -> res2

=== res1 === 
We play touch football and have a great time, get in a great workout and me and %FullName:NPC:1% bond as we play on the same team together.
~TextForLog = "Me and %FullName:NPC:1% have a great time as we play on the same team and strategize together and do really well in our games. Plus, it's a great workout. I think touch football was the right choice."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
Well, it was a good workout for a bit and I was really having to use my strength to take some people down until someone tackles me and I get really hurt.
~TextForLog = "It's pretty fun playing tackle football for awhile and it's a great workout until I get knocked down and have trouble getting back up. I am really banged up. %FullName:NPC:1% even had to help me off the field."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
