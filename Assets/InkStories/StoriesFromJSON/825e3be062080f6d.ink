VAR StoryTittle = ""
VAR StoryQuestion = "But my boss %FullName:NPC:2% wants me to stay late at work if I can. What should I do?"
VAR StoryCategory = "Love:Employer:JobItself"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 60
VAR NPC0RelationshipSc = "Partner"
VAR NPC0MinAgeSc = 22
VAR NPC0MaxAgeSc = 60
VAR NPC1OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0WealthCh = 0

%FullName:NPC:1% asks if I can leave work because %Pron:1:1% wants to spend some time together.
But my boss %FullName:NPC:2% wants me to stay late at work if I can. What should I do?
* [Say I feel sick and leave early]
    -> res1
* [Leave at the usual time]
    -> res2
* [Just work a little overtime]
    -> res3

=== res1 === 
I go home early and %FullName:NPC:1% has a romantic night setup for the two of us.
~TextForLog = "%FullName:NPC:2% is upset with me because %Pron:1:1% thinks I am lying about being sick... which I obviously am. But I don't care about that now. %FullName:NPC:1% has a romantic night setup for me when I come home and I am so glad I left early. We have an incredible night together and I feel even closer to %Pron:1:2%."
~Character0HappinessCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I get home to find out %FullName:NPC:1% planned a special evening for us.
~TextForLog = "Me and %FullName:NPC:1% have a great night together. %Pron:1:1% planned a special evening for us but was hoping I would've gotten home earlier so we could've spent even more time together. More hours together would have been better for sure, but at least we did have this fantastic night and I am so grateful to %Pron:1:2% for planning it."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I get home late to find out %fullName:NPC:1% was trying to plan a special evening for us.
~TextForLog = "I talk to %FullName:NPC:1% and say we can still do a special evening since I am home now but %Pron:1:1% tells me that %Pron:1:1% isn't in the mood anymore. %Pron:1:1% all the food away and goes to bed early and doesn't even want to talk or spend any time together. Meanwhile, %FullName:NPC:2% is happy I stayed late and I made extra money... not sure it was worth it though..."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%100%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
