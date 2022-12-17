VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



My classmate's parents are looking for her, as she hasn't showed up for three nights in a row. But I know that she's been at her boyfriend's. What do I do?
* [Friendly tell her parents everything, for I know they are worried like hell]
    -> res1
* [Send her parents an anonymous message to let them know where she is]
    -> res2
* [Keep it in in secret]
    -> res3
* [Call my classmate and persuade her to get back home]
    -> res4

=== res1 === 
Her parents were grateful to me, but my classmate is seeking revenge on me
~TextForLog = "My classmate didn't sleep at home for three nights in a row, and her parents were looking for her. I told them she was at her boyfriend's, and they were grateful to me. My classmate, however, is seeking revenge on me."
* [Ok]
-> END
=== res2 === 
My classmate's parents took her home, and it all ended well
~TextForLog = "My classmate didn't sleep at home for three nights in a row, and her parents were looking for her. I sent them an anonymous note telling she was at her boyfriend's. They took my classmate home, and it all ended well."
* [Ok]
-> END
=== res3 === 
The police found her, and there was a big scandal cuz she turned out to be pregnant
~TextForLog = "My classmate didn't sleep at home for three nights in a row, and her parents were looking for her. I knew she was at her boyfriend's but I kept this in secret. She was found some days later, safe and pregnant."
* [Ok]
-> END
=== res4 === 
She refused, and I left her alone. Some days later, she was found and brought back home by the police, safe and pregnant
~TextForLog = "My classmate didn't sleep at home for three nights in a row, and her parents were looking for her. I knew she was at her boyfriend's. I called her to persuade her to get back home. She refused, and I left her alone. Later, the police found and brought her home, safe and pregnant."
* [Ok]
-> END