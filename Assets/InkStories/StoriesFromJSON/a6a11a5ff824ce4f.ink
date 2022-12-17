VAR StoryTittle = ""
VAR StoryQuestion = "%FullName:NPC:1% had too much to drink and asks to stay at my place. What do I do?"
VAR StoryCategory = "Love:ColleaguesOrClassmates"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 35
VAR NPC0OccupationSc = "Colleague"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 22
VAR NPC0MaxAgeSc = 35

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0
VAR Character0EnduranceCh = 0

I'm out at a bar with a bunch of work friends.
%FullName:NPC:1% had too much to drink and asks to stay at my place. What do I do?
* [Tell %FullName:NPC:1% that %Pron:1:1% can sleep on the couch.]
    -> res1
* [Tell %FullName:NPC:1% to take my bed and I'll take the couch.]
    -> res2
* [Tell %FullName:NPC:1% that %Pron:1:1% can share my bed.]
    -> res3

=== res1 === 
%FullName:NPC:1% stays on the couch but is upset with me and won't talk to me now.
~TextForLog = "I guess %FullName:NPC:1% wanted something better than the couch... or thought I should've taken the couch. I don't know, I was trying to be polite. I really like %FullName:NPC:1% but now it seems I messed up those chances."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% thinks this is so nice of me and tells everyone how sweet I am.
~TextForLog = "Well, %FullName:NPC:1% was very happy with the fact that I gave %Pron:1:2% my bed and I took the couch. I guess it seemed like the right thing to do. And everyone at work now thinks I am such a nice person... which I guess I kind of am, huh? As long as %FullName:NPC:1% thinks so, I really like %Pron:1:2%."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% hoped I would say that and we end up having an incredible night together.
~TextForLog = "Wow, I really like %FullName:NPC:1% and thought there were some signals that %Pron:1:1% liked me too, I guess I was right. %Pron:1:1% wanted to share the bed with me. Well, I'll just say that we had an amazing night... but in staying up so late, we both called out of work the next day."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END
