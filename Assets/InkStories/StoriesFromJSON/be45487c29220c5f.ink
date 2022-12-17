VAR StoryTittle = ""
VAR StoryQuestion = "What are we, twins?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR Character0GenderSc = "Male"
VAR NPC0RelationshipSc = "Friend"
VAR NPC0OccupationSc = "Classmate"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

%FirstName:NPC:1% has exactly the same lunch pail as me!
What are we, twins?
* [Tell %FirstName:NPC:1% to get a different lunch pail - and stop copying you!]
    -> res1
* [Compliment %Pron:1:2% on his taste in lunch accessories!]
    -> res2
* [Time to prank %FirstName:NPC:1%. Swap the lunch pails around in the fridge!]
    -> res3

=== res1 === 
%FirstName:NPC:1% pushed me over and I grazed my elbow. I suppose I shouldn't boss people around. 
~TextForLog = "I was annoyed that %FirstName:NPC:1% had the same lunch pail as me but when I tried to boss %Pron:1:2% around, he pushed me over. Fair enough, I guess. "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
%FirstName:NPC:1% was happy that I was so nice about his lunch pail. Then we went to play superheroes together! Yippee!
~TextForLog = "It turns out that if you're nice to your friends, they'll pay you back a million times over! %FirstName:NPC:1% and I have the same lunch pail, and you know what? That means we're best buds. "
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
I swapped %FirstName:NPC:1% and I's identical lunch pails around in the fridge. I ended up having to eat his gross guerkin sandwiches, though. But it was really funny! It was worth it!
~TextForLog = "%FirstName:NPC:1% saw the funny side to swapping our packed lunches over, luckily. But he has a horrible taste in sandwiches, I have to say! It was hilarious though!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
