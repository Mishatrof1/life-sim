VAR StoryTittle = ""
VAR StoryQuestion = "Will my friends laugh at me if I ask for help, or chicken out?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR NPC0RelationshipSc = "Friend"
VAR NPC0OccupationSc = "Classmate"
VAR NPC0GenderSc = "Male"
VAR NPC1OccupationSc = "HigherInPosition"
VAR NPC1GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0EnduranceCh = 0
VAR Character0WisdomCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR Character0StrengthCh = 0
VAR Character0AthleticismCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0

It's Active Day at school and I've done everything on the assault course so far. But the climbing wall is really high and that pool of sloppy mud at the bottom looks gross.
Will my friends laugh at me if I ask for help, or chicken out?
* [Chicken out. I hate heights and I really don't want to get muddy. ]
    -> res1
* [Ask for help from %FirstName:NPC:1%. A little help, I bet I can do it!]
    -> res2
* [Ask %FullName:NPC:2% for help over the wall. ]
    -> res3
* [Do it solo. I've got this. ]
    -> res4

=== res1 === 
I decided not to do the climbing wall. Instead, I was able to cheer on %FirstName:NPC:1% while he was doing it, and I could tell it gave him a boost. My classmates laughed a bit, but I don't care. 
~TextForLog = "I chickened out on the climbing wall, which isn't like me usually, but at least it gave me a chance to spur on %FirstName:NPC:1%. He did really well! "
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
%FirstName:NPC:1% was happy to help me when I got to the top and my legs started wobbling. But he wasn't strong enough to catch me when I slipped, and I ended up head first in that sloppy mud. Ouch! 
~TextForLog = "I may've looked like an idiot when I slipped of the climbing wall into that mud, but actually my classmates didn't give me a hard time. %FirstName:NPC:1% gave himself a hard time for failing to catch me, but it wasn't his fault. Whatever doesn't kill you, makes you... muddier!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% got me over the top of the high wall, and when I slipped, grabbed me. When I reached the bottom, I felt giddy but stronger. One of my idiot classmates made a comment, but, whatever. 
~TextForLog = "Since when did getting your teacher's help mean you should be laughed at? The kid that made a comment about that didn't do the climbing wall at all, I noticed, so I guess he can work out which of us is the better person. "
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
I'm brave, but being a coward has its advantages. I attacked that wall. It was going great! I slipped; the mud took me into it's comforting embrace. A little winded, at least I've had a go, right?
~TextForLog = "I made my friends and teacher proud today, having a go at that climbing wall! I don't think I'll ever make a professional climber, but I might make a good mud wrestler! "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
