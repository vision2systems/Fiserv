#X9 ICL 
This code contains an X-9 implementation of cash imagle letters that has a very simple interface to consume.

You start a file, make a few settings, and it will generate an ICL file for deposits only.

The rules for ICL records are kept outside of the actual serialization
of the file.  The serializer for Fiserv has been tested in production with Fiserv sucessfully,  you may need a different serializer
depending on the target for your ICL files.  I tried to add switches to turn off the Big Endian prefix which for example wells fargo does not require
so that you can create serializers that match what your bank needs.

The mapping for the ICL file is handled using a flat file nuget package to map the file values and handle the padding. 


