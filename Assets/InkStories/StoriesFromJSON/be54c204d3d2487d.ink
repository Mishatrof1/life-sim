VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 35
VAR NPC0RelationshipSc = "SignificantOther"
VAR NPC0MinAgeSc = 22
VAR NPC0MaxAgeSc = 35

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WisdomCh = 0
VAR Character0WealthCh = 0

%FullName:NPC:1% says that %Pron:1:1% wonders if we should take our relationship to the next level.
What do I do?
* [Get %FullName:NPC:1% a key to my place.]
    -> res1
* [But %FullName:NPC:1% jewelry.]
    -> res2
* [Tell %FullName:NPC:1% we should sit down and talk about it.]
    -> res3

=== res1 === 
%FullName:NPC:1% loves this and is so ecstatic.
~TextForLog = "It probably was about time I got %FullName:NPC:1% a key to my place and now seemed like the perfect time. And I guess this was the perfect gesture because now %FullName:NPC:1% knows I do care about %Pron:1:2% and am serious about us."
~Character0HappinessCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% gets mad at me and tells me this is not what %Pron:1:1% was thinking.
~TextForLog = "I guess I really messed up. I thought %FullName:NPC:1% would love the jewelry. I spent a lot of money on it. But apparently, %Pron:1:1% was thinking of other things when %Pron:1:1% said 'the next level.' We have a big argument and I do get why %Pron:1:1% is mad at me now. At least I know now, this was supposed to be about us and our relationship. Not presents."
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-110%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res3 === 
We have a long discussion but a very good one and talk about our relationship and what we want.
~TextForLog = "This was actually great for me and %FullName:NPC:1% to sit down and have a big talk about this. We both discuss what we want in our relationship and we realize we want the same exact things and decide we should start to progress and move towards our goals, perhaps living together some day, etc. And I feel we're closer now after having this conversation."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
