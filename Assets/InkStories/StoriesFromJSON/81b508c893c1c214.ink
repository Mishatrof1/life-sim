VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 23
VAR Character0MaxAgeSc = 45
VAR NPC0OccupationSc = "HigherInPosition"

VAR Character0HealthCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0

I wake up late and now I am going to have to rush in order to get to work on time so that my boss isn't upset with me. But I am hungry too.
What should I do?
* [Have my usual coffee and breakfast before work.]
    -> res1
* [Skip my morning routine rush and try to stop off for a coffee on my way to work.]
    -> res2
* [Skip my morning routine, rush, stop off for a breakfast sandwich before work.]
    -> res3

=== res1 === 
I do my usual routine, have my coffee and healthy breakfast that prepares me for the day. %FullName:NPC:1% is mad at me for being late but I still manage to be productive.
~TextForLog = "%FullName:NPC:1% is pretty mad at me for being late, but I just wanted to still make the healthy choice and eat my usual breakfast and not skip a meal or anything. I'm still really productive at work, not that %FullName:NPC:1% cares."
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I get a coffee before work and actually end up getting to work early what with all the rushing. My boss is happy to see me arrive early, but I feel so weak having skipped breakfast.
~TextForLog = "The coffee is really strong and keeps me awake and allows me to be productive and %FullName:NPC:1% is happy I am early. But I am feeling weaker and weaker as the day goes on and just waiting for lunch. I'm starving!"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-5%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I stop and get a breakfast sandwich and manage to make it to work early with all the rushing. At least I ate something but this sandwich is so heavy and now I'm tired and slow.
~TextForLog = "%FullName:NPC:1% is happy I arrived early but I don't know of how much use I'll be. I rushed to get ready, had no coffee, skipped my morning routine and had a fatty and heavy breakfast sandwich. This day can't END soon enough."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-7%"
~NPC0HappinessCh = "%%"
~NPC0RelationshipCh = "%%"
* [Ok]
-> END
