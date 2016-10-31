# DevIntersection2016EFCore
Demos for EF Core session (uses EF 1.1 Preview)

These are my demos and slides from Oct 2016 Devintersection.com

For those in attendance: I made 2 discoveries since doing the talk which change 2 pieces of information I shared with you.  

1) Although it is still true that field mappings only work with scalar properties (and that navigation properties will be supported soon), it IS indeed possible to encapsulate collection properties to prevent anyone from adding/removing items directly. That's possible (as of EF 1.1) because EF will now allow mapping to IEnumerables. See this blog post by EF team dev (you should follow his blog!) Arthur Vickers about this support: [Collection navigation properties and fields in EF Core 1.1] (https://blog.oneunicorn.com/2016/10/28/collection-navigation-properties-and-fields-in-ef-core-1-1).  

2) I didn't mention this in the talk but someone asked me after the session if it was possible yet to defined a read-only DbContext. It's something I've been asking for for many years and did not realize that EF Core has a way to do that now! But i didn't know about it and unfortunately told him that it wasn't supported. I've just blogged about how to create read-only DbContexts here: [EF Core Lets Us Finally Define NoTracking DbContexts](http://thedatafarm.com/data-access/ef-core-lets-us-finally-define-notracking-dbcontexts/).
