VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool:College"
VAR NPC0RelativesSc = "Sibling:StepSibling"
VAR NPC0GenderSc = "Male"
VAR NPC1RelativesSc = "Sibling:StepSibling"
VAR NPC1GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HealthCh = 0

At the arcade with my family and I have an extra token that my brother and my sister both want.
What do I do?
* [Give it to my brother]
    -> res1
* [Give it to my sister]
    -> res2
* [Give the token to some other young kid in the arcade to use]
    -> res3
* [Decide to keep it myself and use it for a game]
    -> res4

=== res1 === 
My sister gets mad at me and storms off, my brother is ecstatic and he wins a bunch of tickets that he shares with me.
~TextForLog = "Of course my sister gets mad because I chose my brother but I think it was the right choice because he won big and we got a ton of tickets! Oh, the prizes I can choose now!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
My sister is so happy to play another game but my brother gets so mad that he and I get in a fight.
~TextForLog = "Of course my brother gets mad because I choose my sister but he went too far and we end up getting into a fight right in the middle of the arcade! Kind of embarrassing..."
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Everyone agrees that this was a nice thing to do and we all get food together, however, I have an allergic reaction to something I eat.
~TextForLog = "We all felt good giving the token to another kid there to let him enjoy some more games and I would have felt really great had I not had an awful allergic reaction to the food we then ate!"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My sister gets angry with me but my brother actually finds this hilarious and roots me on while I play my game.
~TextForLog = "I’m glad I just kept the token for myself, I wasn’t done playing and my brother rooted me on. I just wish my sister wouldn’t have gotten so mad at me."
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
