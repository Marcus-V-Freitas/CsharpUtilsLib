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
  >- DictionaryIsNull
  >- DictionaryIsEmpty
  >- ListIsNullOrEmpty
  >- ListIsNull
  >- ListIsEmpty
  >- AddIfNotNull (ICollection, IDictionary)
  >- AddOrChangeValue
  >- AddOrChangeValueByIndex
  >- KeyValueIsNull
  >- AddRangeIfNotNullOrEmpty
  >- TryGetValue (IDictionary, Arrays, IList, KeyValuePair)
  >- ToNullList
  >- AddIfNotEmptyOrNull
  >- KeyValueIsNullOrEmpty
  >- ToDefaultListIfNull
  >- ToDistinctList
  
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
  >- Clone
  >- ConvertTo

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
  >- Correios Tracking (class)
  >- Correios Shipping (class)
  >- IBGE News (class)
  >- Inflation (class)
  
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
  >- IHttpWrapper (interface) 
 
 ---
 
* **Numerics**

> Operations with numbers:
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

> Operations with reflection:
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

* **SQL**

> Operations with databases (Mysql, PostgreSql, SqlLite, SqlServer):
  >- InsertWithId / InsertWithIdAsync
  >- Insert / InsertAsync
  >- Update / UpdateAsync
  >- Delete / DeleteAsync
  >- Exists / ExistsAsync
  >- SelectOne / SelectOneAsync
  >- Select / SelectAsync
  >- ExecuteNonQuery / ExecuteNonQueryAsync
  >- ExecuteScalar / ExecuteScalarAsync
  >- ExecuteReader / ExecuteReaderAsync

---

* **Texts**

> Operations with strings:
  >- RemoveSpecialCharacters 
  >- SplitStringWithoutNullOrEmpty
  >- GenerateRandomPassword
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
  >- ConvertToString
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

> Generic operations:
  >- IsValidEmail
  >- IsValidEAN
  >- IsValidIpAddress
    
--- 

* **SystemResources**

> Monitoring system resources (memory, cpu and time):
  >- TaskMonitor (class)

--- 

* **Tasks**

> Operations with tasks:
  >- FireAndForget
  >- Retry
  >- OnFailure
  >- WithTimeout
  >- Fallback
  >- TryAsync

--- 

* **XML**

> Operations with xml:
  >- GetElementValue
  >- AddElement
  >- GetAttributeValue
  >- RemoveElement
  >- ToXmlElement
  >- ToObject
  >- SerializeObjectToXml
  >- DeserializeXmlToObject
