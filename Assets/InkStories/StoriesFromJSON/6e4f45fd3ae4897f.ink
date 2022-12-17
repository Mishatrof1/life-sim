VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Friends:Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 21
VAR Character0MaxAgeSc = 30
VAR NPC0RelationshipSc = "SignificantOther"
VAR NPC0MinAgeSc = 21
VAR NPC0MaxAgeSc = 30

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

My birthday is coming up and %FullName:NPC:1% wants to plan my birthday outing and surprise me.
What do I do?
* [Let %FullName:NPC:1% plan it.]
    -> res1
* [Tell %FullName:NPC:1% I want to invite my friends to a bar I really like.]
    -> res2

=== res1 === 
%FullName:NPC:1% picks an excellent venue and invites all my friends and it's a fantastic time.
~TextForLog = "I got to hand it to %FullName:NPC:1%, she did an amazing job planning my birthday party. %Pron:1:1% invited all my friends that I wanted there, the place was amazing, I had never heard of it but every single one of us had an amazing time. And to think I was starting to doubt %Pron:1:2% a little bit. Never again!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
I invite everyone and we have a really good time, except %FullName:NPC:1% is mad at me.
~TextForLog = "Well, everyone enjoyed the spot I picked, except for %FullName:NPC:1%. Maybe it wasn't that %FullName:NPC:1% didn't enjoy it, %Pron:1:1% may have just been upset with me for not letting %Pron:1:2% plan the outing. But I didn't know what place %Pron:1:1% would pick. What if I didn't like it? I feel this was the safer approach. Where I know I'll enjoy myself."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
