: shellinc ( list size inc -- ) { l s n -- }
  s n > if
    s n -
    0
    do
      l i thelem
      l i n + thelem
      > if
        l i thcell
        l i n + thcell
        swapcell
        then
      loop
    then ;

: shellsort ( list size -- ) { l s -- }
  l s 7 shellinc
  l s 5 shellinc
  l s 3 shellinc
  l s 1 shellinc ;
