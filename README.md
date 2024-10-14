# X9 ICL for Deposits and begining of ACH API implementation for NACHA standard API
This code contains an X-9 implementation of cash imagle letters that has a very simple interface to consume.

You start a file, make a few settings, and it will generate an ICL file for deposits only.

## ICL Serialization
The rules for ICL records are kept outside of the actual serialization
of the file.  The serializer for Fiserv has been tested in production with Fiserv sucessfully,  you may need a different serializer
depending on the target for your ICL files.  I tried to add switches to turn off the Big Endian prefix which for example wells fargo does not require
so that you can create serializers that match what your bank needs.

The mapping for the ICL file is handled using a flat file nuget package to map the file values and handle the padding. 

## ICL Example Usage

    var fileBuilder = new ICLFileBuilder();
    fileBuilder.ImmediateDestinationRoutingNumber = "999944442";
    fileBuilder.DepositAccountNumber = "11111111111";
    fileBuilder.ImmediateOriginRoutingNumber = "111017979";
    fileBuilder.ContactName = "Joe Smith";
    fileBuilder.ContactPhoneNumber = "2145551212";
    fileBuilder.FileDate = DateTime.UtcNow;
    fileBuilder.ImmediateDestinationName = "Test Bank";
    fileBuilder.ImmediateOriginName = "TESTCompany";
    fileBuilder.CustomerName = "Test";
    
    using (var cashLetter = fileBuilder.CreateCashLetter(1))
    {
        using (var bundle = cashLetter.CreateBundle(1,1))
        {        
            var frontImage = new byte[1024];
            var backImage = new byte[1024];
            bundle.AddDepositWithCheckImages(100,"111000614","1111111111","0101",null,frontImage, backImage, 1, DateTime.UtcNow);
        }
    }

    var serializer = new FiservICLFileSerializer();
    var fileName = serializer.GetFileName(fileBuilder);
    var bytes = serializer.Serialize(fileBuilder);


