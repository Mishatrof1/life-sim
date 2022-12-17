VAR StoryTittle = ""
VAR StoryQuestion = "What should I say?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0StrengthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC0HappinessCh = 0

%FullName:NPC:1% gets a little injured during our basketball game and %Pron:1:1% is trying to decide if %Pron:1:1% can go back in and play.
What should I say?
* ["Just rest if you need to. Don't hurt yourself."]
    -> res1
* ["You're tough, I think you can play through it."]
    -> res2
* ["Don't be a baby! Get in the game!"]
    -> res3

=== res1 === 
%FullName:NPC:1% takes it easy and doesn't play the rest of the game which means I need to play more minutes and exert myself even more in the game. But we win!
~TextForLog = "%FullName:NPC:1% was unsure if %Pron:1:1% should go back in so I told %Pron:1:2% to take it easy if %Pron:1:1% felt that %Pron:1:1% should and that's exactly what %Pron:1:1% did. %Pron:1:1% must have been in too much pain. Meanwhile, I end up playing way more minutes and it feels like such a long game but we manage to win!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:1:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:1:+%"
~Character0AthleticismCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My encouraging words get %FullName:NPC:1% ready to play the game and %Pron:1:1% does come in and is able to play well. We play together with great chemistry and win the game!
~TextForLog = "I'm so happy that we won and that %FullName:NPC:1% came back in the game to help us win, but I am really most proud of myself for encouraging %Pron:1:2% to get back in and play. We grow closer and %Pron:1:1% really leans on me for support and encouragement throughout the game."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
I tried tough love but it didn't work with %FullName:NPC:1% at all. %Pron:1:1% and I get in an argument, %Pron:1:1% sits out and we lose the game.
~TextForLog = "I thought the tough love approach would work with %FullName:NPC:1% but %Pron:1:1% had the opposite reaction I hoped for. We got in an argument and then %Pron:1:1% said %Pron:1:1% was too injured to play. Maybe that's the truth, I don't know. But without %Pron:1:2% we suffer and I have to play so many minutes but we wind up losing the game."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:+%"
~Character0EnduranceCh = "%ValueRef:1:+%"
~Character0AthleticismCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%%"
~NPC0RelationshipCh = "%%"
* [Ok]
-> END
