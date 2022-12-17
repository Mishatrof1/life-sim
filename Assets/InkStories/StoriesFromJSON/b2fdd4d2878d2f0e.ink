VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 55
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Opposite"

VAR Character0HappinessCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR Character0IntelligenceCh = 0

Me and %FullName:NPC:1% are looking for a class down at the community center we can take together.
What should we do?
* [Take a cooking class.]
    -> res1
* [Take a karate class together.]
    -> res2
* [Take swing dancing classes.]
    -> res3

=== res1 === 
We learn all sorts of great new dishes to make and really enjoy it. Everything we end up making is delicious and very fatty.
~TextForLog = "Me and %FullName:NPC:1% are basically gourmet chefs now. After many, many cooking classes we've nailed so many great dishes. We're having a great time together, but we're really packing on the pounds..."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
The karate class is a lot of work but it really helps us to get into good shape. And we learn a lot about self-defense too.
~TextForLog = "I'm glad that %FullName:NPC:1% and I took the karate class, we really got to be quite good at it and learned a lot. And we both feel like we're in such better shape now. Plus, no attackers can get to us now!"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-100%"
* [Ok]
-> END

=== res3 === 
This is absolutely so much fun! It's more of a workout than I expected and %FullName:NPC:1% and I are really connecting more.
~TextForLog = "Taking these classes not only was fun and a good workout, but %FullName:NPC:1% and I really connected deeper than we have in a long time. This was so good for us and I am so happy. Of course, it was pricey!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-200%"
* [Ok]
-> END
