: countlesser ( list size n -- n ) { l s n -- n }
  0
  s 0 do
    l i thelem
    n < if
      1+
      then
    loop ;

: countsort ( list size -- ) { l s -- }
  here s 2* cells erase
  s 0 do  \ count
    here i            \ list & index
    l s
    l i thelem
    countlesser       \ n
    set
    loop

  s 0 do  \ make new sorted list
    here              \ list
    here i thelem s + \ index
    l i thelem        \ n
    set
    loop

  s 0 do  \ replace with sorted
    l
    i
    here s i + thelem
    set
    loop ;
