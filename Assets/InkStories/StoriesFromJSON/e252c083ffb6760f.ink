VAR StoryTittle = ""
VAR StoryQuestion = "I'm supposed to go to %FullName:NPC:1%'s house and hang out with friends. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 15
VAR Character0MaxAgeSc = 22
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"
VAR NPC0MinAgeSc = 15
VAR NPC0MaxAgeSc = 22
VAR NPC1OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WealthCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC0HappinessCh = 0

I'm done with work but my boss %FullName:NPC:2% asks if I can stay and help %Pron:2:2% with some other things that need to be done.
I'm supposed to go to %FullName:NPC:1%'s house and hang out with friends. What should I do?
* [Just go to %FullName:NPC:1%'s house.]
    -> res1
* [Help %FullName:NPC:2% take all the trash out.]
    -> res2
* [Help %FullName:NPC:2% and clean the bathrooms.]
    -> res3

=== res1 === 
My boss is fine with this and I go have a fun time with %FullName:NPC:1% and our friends.
~TextForLog = "I know I could've gotten some extra money if I stayed but I just didn't feel like it. I was done with work and just wanted to go hang out with %FullName:NPC:1% and our other friends. And it was a fun time and a good way to unwind after work."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
The trash bags rip open and spill all over me, but I also find $75 in the trash!
~TextForLog = "%FullName:NPC:2% is happy I helped %Pron:2:2% out and paid me $50 extra. In addition to that, I found $75 in the trash. But it came at the cost of spilling stinky trash all over myself so when I get to %FullName:NPC:1%'s house all our other friends are disgusted by me and how badly I smell."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~Character0WealthCh = "%125%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I make $50 for cleaning the bathrooms but it makes me late to %FullName:NPC:1%'s house.
~TextForLog = "Well, I got the extra $50 and %FullName:NPC:2% is happy with me for helping out but now I wish I didn't do it because it took me so long that I wind us being really late to get to %FullName:NPC:1%'s place and %Pron:1:1% is annoyed with me now."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%50%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
