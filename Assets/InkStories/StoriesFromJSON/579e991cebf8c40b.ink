VAR StoryTittle = ""
VAR StoryQuestion = "Should I show him what I can do or not?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR NPC0RelationshipSc = "Friend"
VAR NPC0OccupationSc = "Classmate"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0StrengthCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AthleticismCh = 0
VAR Character0EnduranceCh = 0

Strong! I can now do the monkey bars, all the way to the end! I'm so proud; I want to show %FirstName:NPC:1%... But %FirstName:NPC:1% can't do them, he gets puffed and has to drop down at the end.
Should I show him what I can do or not?
* [Yes, do the monkey bars. He's my friend, he'll be happy for me!]
    -> res1
* [Help him get the 'hang' of it!]
    -> res2
* [Don't show him. Play something else. ]
    -> res3

=== res1 === 
I don't know whether he was jealous or just annoyed with himself, but %FirstName:NPC:1% got moody. He didn't congratulate me or anything. We kind of fell out. 
~TextForLog = "I suppose you shouldn't show off what you can do, or you should just be more careful about it. I could do the monkey bars, but %FirstName:NPC:1% couldn't, and didn't appreciate me showing him how it was done."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FirstName:NPC:1% was so chuffed when I offered to help him with the monkey bars, and all he needed was a little lift. I got a chance to demonstrate too, and he high fived me!
~TextForLog = "I helped %FirstName:NPC:1% with his monkey bar skills. I love hanging with my mates!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FirstName:NPC:1% and I had a funny game of doctors and nurses, and left the park tired and still friends. I wished I could've shown him the monkey bars, but I guess I saved his feelings. 
~TextForLog = "Is it always good to be modest? Sometimes I think it's important to show people what you can do! I guess I spared %FirstName:NPC:1%'s feelings, but so what if I can do the monkey bars and he can't!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
