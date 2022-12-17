VAR StoryTittle = ""
VAR StoryQuestion = "Which one should we take?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool:College"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 23
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR Character0StrengthCh = 0

Me and %FullName:NPC:1% are at the gym and they're offering some different classes.
Which one should we take?
* [The regular boxing class.]
    -> res1
* [Bare knuckle boxing classes.]
    -> res2

=== res1 === 
We take the class, they give us boxing gloves and have us spar with one another and it turns out to be fun and great exercise.
~TextForLog = "Me and %FullName:NPC:1% have fun sparring with each other with the gloves on. We get in a great workout too! I feel very energized and we keep talking about it afterwards and might be planning on going back again."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We choose this and it's a good workout until we end up hitting each other too hard and then it turns into us trying to hurt one another.
~TextForLog = "Me and %FullName:NPC:1% both got annoyed with one another when we hit each other too hard and then it turned into a personal thing. We were actually trying to hurt one another. %Pron:1:1% started it though, I was just retaliating. I'm so mad at %Pron:1:2% I leave by myself, but I suppose it was a good workout. Was the black eye worth it though?"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:1:+%"
~Character0AthleticismCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-40%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
