grammar CardLanguage;

body : open childNode close ;
childNode : open childNode close childNode | open childNode close | many ;

open : '(' ;
many : ANY+? ;
ANY : . ;
close : ')';