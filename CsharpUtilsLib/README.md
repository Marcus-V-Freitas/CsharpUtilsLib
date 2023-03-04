# CsharpUtilsLib

>>  Lib with methods to facilitate day-to-day development with C#.

---

* **Brazil**

> Format Brazilian documents and others things:
  >- FormatPIS
  >- FormatCPF
  >- FormatCNPJ
  >- FormatPhoneNumber
  >- FormatCEP
  >- FormatNCM
  >- FormatFIPECode

> Validate Brazilian documents and ohers things:
  >- IsValidCNPJ
  >- IsValidCPF
  >- IsValidPis
  >- IsValidVoterIDCard (Título de Eleitor)
  >- IsValidCep
  
> Others
  >- BrazilProcessNumber (class)
  
---
  
* **Collections**

> Operations with collections:
  >- ConcatLists
  >- GetRandomElement
  >- BubbleSort
  >- MostFrequent
  >- DictionaryIsNullOrEmpty
  >- ListIsNullOrEmpty
  >- AddIfNotNull (ICollection, IDictionary)
  >- AddOrChangeValue
  >- AddOrChangeValueByIndex
  >- KeyValueIsNull
  >- AddRangeIfNotNullOrEmpty
  >- TryGetValue (IDictionary, Arrays, IList, KeyValuePair)
  >- ToNullList
  
---
  
* **Crypto**

> Encryption algorithms
  >- AesCrypto
  >- Base32
 
---

* **Date**

> Operations with date objects:
  >- GetAllYearDates
  >- GetLastDayOfWeek
  >- GetFirstDayOfWeek
  >- LastDayOfMonth
  >- GetAge
  >- IsWeekend
  >- IsWeekday
  >- IsBetweenDates
  >- GetNextWeekday
  >- GetWeekdayCount
  >- ConvertToDatetime

---

* **Enums**

> Operations with enums:
  >- GetEnumValuesAndNames
  >- GetEnumValues
  >- GetDisplayName
  >- GetEnumName
  >- GetEnumValue

---

* **Extensions**
  >- GetRandom
  >- With

---

* **External**

> Operatons with external tools:
  >- Companies (class)
  >- FIPE table (class)
  >- IP (class)
  >- NCM (class)
  >- National Brazil Holidays (class)
  >- Taxs (class)
  >- CEP (class)
  >- Country (class)
  >- GoogleTranslate (class)
  >- ISBN (class)
  >- Ticker (class)
  >- Temperature (class)
  >- Meal (class)
  >- Inflation (class)
  >- Geolocation (class)
  >- English Dictionary (class)
  >- Currency Converter (class)
  
 ---
 
* **FilesDirectories**

> Operations with files and/or directories:
  >- DeleteFile
  >- DeleteFolder
  >- IsXML
  >- IsJson
  >- IsHTML
  >- CreateDirectoryIfNotExists
  >- CreateFileIfNotExists
  >- CreateLocalFileIfNotExists
  >- CreateLocalDirectoryIfNotExists
  >- FileTypeIdentify (class)
  >- GetDirectorySizeContent
  >- RenameFile
  >- ClearDirectoryContent
  >- CopyDirectoryContent
  >- CreateTextFileWithContent
  >- MergeFiles
  
---

* **HTTP**

> Operations with http requests:
  >- HttpWrapper (class)
 
 ---
 
* **Numerics**

> Operation with numbers:
  >- GetLongestSequence
  >- RandomNumbers
  >- IsInRange
  >- GetMissingNumbers
  >- IsNumeric
  >- GetAverage
  >- Factorial
  >- IsEven
  >- IsOdd
  >- IsPrime
  >- StandardDeviation

 ---
 
* **Reflecions**
  >- GetDisplayName
  >- DefaultConstructor
  >- CreateInstance
  >- InvokeMethod
  >- SetPropertyValue
  >- GetPropertyValue
  >- GetStringPropertyValue
  >- SetFieldValue
  >- GetFieldValue
  >- GetStringFieldValue
  >- GetFullTypeName
  >- HasPropertyOrField

---

* **Texts**

> Operation with strings:
  >- IsSequentialRepetition
  >- RemoveAllWhitespace
  >- MultiReplace
  >- GetMostFrequentSeparator
  >- CountOcurrences
  >- RemoveDiacritics
  >- MatchFirstOcurrency
  >- MatchListOcurrencies
  >- RemoveDuplicateWords
  >- GetUniqueKey
  >- RemoveDocumentMask
  >- ToTitleCase
  >- SpecificSplit
  >- Count 
  >- OnlyNumbers
  >- SafeSubstring
  >- ToByteArray
  >- ToByteArrayAscii
  >- ToAscii
  >- ToUTF8
  
---

* **Web**

> Operations involving captures on the internet:
  >- HtmlString (class)
  >- CurrentPage and PageMetaData (Pagination classes)
  >- RandomUserAgent (class)
  >- Pagination
  >- ToFormPostData
  >- ToJsonPostData
  >- GetQueryStringValue
  >- GetAllQueryStringValues
  >- AddQueryString
  >- IsValidUrl
  >- GetHeader
  >- CombineUrl
  >- ClearHtml

---

* **Global**

> Generic operations
  >- IsValidEmail
  >- IsValidEAN
  >- IsValidIpAddress
    
--- 

* **SystemResources**

> Monitoring system resources (memory, cpu and time)
  >- TaskMonitor (class)
