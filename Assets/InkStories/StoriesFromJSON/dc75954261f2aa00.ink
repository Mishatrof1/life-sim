VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 30
VAR Character0GenderSc = "Male"
VAR Character0SexualPreferencesSc = "Straight"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0PopularityCh = 0
VAR Character0AppearanceCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0WisdomCh = 0

I wake up in the middle of the night and see a blue-ish lady hovering over the foot of my bed.
What should I do?
* [Hide under the blankets.]
    -> res1
* [Run out of the room]
    -> res2
* [Ask her what she is doing]
    -> res3

=== res1 === 
I hide under the blankets and the lady climbs under the blankets with me and stares creepily at me for minutes before leaving.
~TextForLog = "This was such a terrifying night, this blue-ish lady that HAD to be a ghost, crawling under my covers with me. I was frozen with fear. I told my friends the next day and they're all laughing at me and teasing me about my new blue girlfriend who spends the night at my place. So stupid, why did I even tell them? Meanwhile, I feel sick from getting no sleep."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I get up to run out of the room but the lady flies over to my door and it flings open and smashes into my face.
~TextForLog = "I end up going to the hospital with a broken nose and two black eyes. The doctors keep asking what happened and I just keep saying I fell out of bed. There is no way I am telling them about this ghost in my room, they will think I am crazy! After that I can't go back home, I find a 24 hour library and read until the sun comes up."
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
She tells me that she is looking for her husband. I tell her that her husband doesn't live here anymore.
~TextForLog = "I think this lady may be the woman who used to live here with her husband just before me. I tell her that her husband isn't here anymore, it takes me saying it a couple of times and she seems confused but she eventually vanishes. And then I don't see her anymore. Wow, she just needed to be told what was happening because she didn't know. I am still so stunned."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
* [Ok]
-> END
