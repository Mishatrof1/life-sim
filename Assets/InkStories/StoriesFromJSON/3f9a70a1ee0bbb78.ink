VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"
VAR NPC1RelationshipSc = "Crush"
VAR NPC1GenderSc = "Opposite"
VAR NPC2RelativesSc = "Parent"
VAR NPC2GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC2HappinessCh = 0
VAR NPC2RelationshipCh = 0

I'm supposed to go home for dinner but both %FullName:NPC:1% and %FullName:NPC:2% invite me to dinners with them separately.
What should I do?
* [Go to dinner with %FullName:NPC:1%]
    -> res1
* [Go to dinner with %FullName:NPC:2%]
    -> res2
* [Go home for dinner and save my money.]
    -> res3

=== res1 === 
We go to a barbecue place and it's delicious and so bad for you. Both %FullName:NPC:2% and %Full:Name:NPC:3% are disappointed I didn't have dinner with them.
~TextForLog = "%FullName:NPC:3% is upset I didn't come home for dinner. %FullName:NPC:2% is upset I didn't take %Pron:2:2% up on %Pron:2:2% offer. Everybody, I can only be one place at a time! At least me and %FullName:NPC:1% had a great time! Oh, but I feel so fat now."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-30%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
~NPC2HappinessCh = "%ValueRef:0:-%"
~NPC2RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:3% and %FullName:NPC:1% both understand that I want to go out with %FullName:NPC:2% and aren't mad. We eat at a great French restaurant but it is expensive!
~TextForLog = "Wow, me and %FullName:NPC:2% had an amazing time! I'm so glad I went with %Pron:2:2%. The food was delicious, very fattening though. And quite expensive. I didn't realize I would be spending so much money. But I guess it's worth it."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-70%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Both %FullName:NPC:1% and %FullName:NPC:2% understand and both say we should plan for another time. %FullName:NPC:3% makes a healthy and delicious dinner for us and we have a nice night.
~TextForLog = "%FullName:NPC:3% is happy I still came home for dinner and actually I am too. I saved money and didn't spend a bunch eating out. And our dinner was really healthy and still tasty. I didn't feel so tired and out of it after dinner, I felt good! I should probably eat like this more often."
~Character0HealthCh = "%ValueRef:0:+%"
* [Ok]
-> END
