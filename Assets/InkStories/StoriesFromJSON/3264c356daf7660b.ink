VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Cyan"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0RelativesSc = "Parent"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 40
VAR NPC0MaxAgeSc = 65

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

It's my birthday party and %FullName:NPC:1% is trying to hand feed me a piece of cake.
What should I do?
* [Just eat it, the cake looks delicious.]
    -> res1
* [Tell %FullName:NPC:1% no.]
    -> res2

=== res1 === 
The cake is delicious and my %FullName:NPC:1% is having a good time but my friends capture this on video and now I am a laughingstock.
~TextForLog = "At the sake of doing something to not upset %FullName:NPC:1% I have now jeopardized my whole school career. Everyone is making fun of me now... and I totally understand why! This video is awful!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% gets offended but all my friends think it's hilarious the way I talk to %Pron:1:2%.
~TextForLog = "I'm happy my friends thought I was hilarious and also I think I avoided a really awkward looking situation at my own birthday party. But %FullName:NPC:1% is really upset with me now. But whatever! I'm not 2 years old, that was really weird!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
