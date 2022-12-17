VAR StoryTittle = ""
VAR StoryQuestion = "I need to buy the gift without %Pron:1:2% knowing. What should I do?"
VAR StoryCategory = "Friends:Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 45
VAR NPC0RelationshipSc = "Partner"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 45
VAR NPC1RelationshipSc = "Friend"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0

I want to surprise %FullName:NPC:1% with a gift.
I need to buy the gift without %Pron:1:2% knowing. What should I do?
* [Tell %FullName:NPC:1% I am going to hang out with %FullName:NPC:2% and then go buy the gift.]
    -> res1
* [Ask %FullName:NPC:2% to buy the gift for me.]
    -> res2
* [Tell %FullName:NPC:1% I am going to the movies alone, then get the gift.]
    -> res3

=== res1 === 
%FullName:NPC:1% calls %FullName:NPC:2% to tell me I forgot my cell phone and I'm not there and %Pron:1:1% thinks I'm cheating.
~TextForLog = "Unfortunately, I forgot my cell phone and %FullName:NPC:1% wanted to let me know but when %Pron:1:1% called %FullName:NPC:2% and I wasn't there, %Pron:1:1% assumed the worst. %Pron:1:1% thinks I am cheating or something and is so mad at me now. I'm trying to explain it was to get %Pron:1:2% gift but it just sounds like an excuse now."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-60%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
I give %FullName:NPC:2% money to buy the gift and am able to surprise %FullName:NPC:1% completely.
~TextForLog = "%FullName:NPC:1% is so happy when I surprise %Pron:1:2% with the gift. %Pron:1:1% is so astonished because I never even left %Pron:1:2% sight. And I'm so thankful to %FullName:NPC:2% for helping me out, what a true friend. %Pron:2:1% even got a little tip out of it for helping me out and coming through."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-75%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% is originally mad thinking I want to watch a movie without %Pron:1:2% but once %Pron:1:1% gets the gift %Pron:1:1% is even happier.
~TextForLog = "It started off a little rocky because %FullName:NPCL1% was mad at me and thought I was being selfish for wanting to go to the movies alone. And even though things started off bad, it ended up in an even better surprise when I came back early with the gift. %Pron:1:1% was so happy with me and absolutely loved the surprise!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-60%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END
