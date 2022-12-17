VAR StoryTittle = ""
VAR StoryQuestion = "What should I wear on the date?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 15
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 15
VAR NPC0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR Character0StrengthCh = 0
VAR NPC0SympathyCh = 0

I have a date with %FullName:NPC:1% tonight but I am nervous.
What should I wear on the date?
* [Keep on the button down shirt that I am wearing.]
    -> res1
* [Put on my back-up sweater.]
    -> res2

=== res1 === 
%FullName:NPC:1% tells me %Pron:1:1% loves my shirt and we have a great date.
~TextForLog = "%FullName:NPC:1% liked the shirt I had on so I am glad I didn't change. And our date went amazingly!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
As I put the sweater on I accidentally swing my arms and hit another kid who proceeds to fight me.
~TextForLog = "I can't believe it! I am just trying to put the sweater on and accidentally hit some kid and now the kid is trying to fight me. We get into a whole fight before it's broken up and this kid definitely got plenty of shots in on my face! Right before my date!"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
