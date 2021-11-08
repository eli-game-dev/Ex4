<div dir='rtl' lang='he'>

# Ex4
itch.io link: https://eliyahup.itch.io/ex4

במטלה הזאת הוספתי מספר עצמים ורכיבים.

1. הוספתי אפשרות להגביל את קצב הירי ל0.5 שניות(ניתן לשנות דרך יוניטי) נעזרתי בקוד מההרצאה 
ע"י שימוש בIEnumerator והחזרה לאחר חצי שניה בנוסף נעזרתי במשנתים בוליאנים על מנת לא לקרוא לפונקציה שוב ושוב.
[LaserShooter](https://github.com/eli-game-dev/Ex4/blob/main/Assets/Scripts/2-spawners/LaserShooter.cs)

2. הוספתי אפשרות רדומלית להוסיף אובייקטים בגבולות של המסך 
[randomObjectOnScreen](https://github.com/eli-game-dev/Ex4/blob/main/Assets/Scripts/2-spawners/randomObjectOnScreen.cs)
אם השחקן לא אוסף את האובייקט בזמן מסויים האובייקט נעלם.

הוספתי שבזמן רנדומלי יהיו על המסך מגנים, כאשר השחקן אוסף את המגנים המגן נעלם 
ומסביב השחקן נוצר מגן בצורת עיגול המגן נחלש כל פעם קצת ביחס לזמן שהוקצב למגן.
בנוסף כאשר השחקן אוסף מגן נוסף המגן החדש מתווסף ומתחיל להגן מתחילת הזמן שהוגדר(לפי מה שהוגדר ביוניטי).
כאשר ההגנה מופעלת אם מתנגשים באויב השחקן לא מושמד וגם אין gameOver.
נעזרתי בקוד שהמרצה כתב בשביל להשתמש בהגנה והוספתי עליו דברים.
[ShieldThePlayer](https://github.com/eli-game-dev/Ex4/blob/main/Assets/Scripts/3-collisions/ShieldThePlayer.cs)

3. הוספתי שבזמן רדומלי יהיו על מסך עיגולים מאש(מדמה סילון) שבעצם כאשר השחקן אוסף את הסילון 
נוספת לו אנימציה מאש כמו סילון מתחת לחללית והשחקן נוסע במהירות גבוהה יותר. כשאר השחקן אוסף סילון נוסף תוך כדי
הזמן שנותר לסילון מתאפס מהתחלה בדומה למגן.
[AddJetPlayer](https://github.com/eli-game-dev/Ex4/blob/main/Assets/Scripts/3-collisions/AddJetPlayer.cs)

</div>
