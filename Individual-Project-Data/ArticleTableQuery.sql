select ar.AuthorName, ar.[AuthorId], ar.[Title], au.[AuthorName], ar.[Content]  from
Authors au
inner join Articles ar on au.AuthorName = ar.AuthorName