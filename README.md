# Plugin.XamarinForms.Converters

Cross platform library containing a bunch of XAML converters for Xamarin Forms.

### Supported platforms

| Name | Tested |
| - | - |
| Android | Yes |
| iOS | Yes |

## Setup

Install this package into your PCL/.NetStandard project. It does not require additional configurations.

## Using the package

First, you just need to add the reference in your XAML file:

```XML
xmlns:conv="clr-namespace:Plugin.XamarinForms.Converters;assembly=Plugin.XamarinForms.Converters"

xmlns:enum="clr-namespace:Demo.Enums"
```

And then you can use it on this way:

```XML
<Entry Text="{Binding Text, Mode=TwoWay}" TextColor="DimGray" Placeholder="Enter a text" Keyboard="Text" />
            
<Label Text="{Binding Text, Converter={conv:ToLowerCaseConverter}}" />
            
<Label Text="{Binding Text, Converter={conv:SubstringConverter, MaxLenght=35}}" />

<Entry Text="{Binding Number, Mode=TwoWay, Converter={conv:EmptyToZeroConverter}}" Keyboard="Numeric" />

<Picker ItemDisplayBinding="{Binding ., Converter={conv:EnumDescriptionConverter}}"
        SelectedItem="{Binding EventType, Mode=TwoWay}">
    <Picker.ItemsSource>
        <x:Array Type="{x:Type enum:EventType}">
            <enum:EventType>None</enum:EventType>
            <enum:EventType>Movie</enum:EventType>
            <enum:EventType>Concert</enum:EventType>
            <enum:EventType>Sports</enum:EventType>
            <enum:EventType>CityTour</enum:EventType>
        </x:Array>
    </Picker.ItemsSource>
</Picker>

<Label Text="{Binding YourBooleanValue, Converter={conv:BoolToObjectConverter IfTrue='Represents True', IfFalse=500}}" />
```
Enum declaration:

```C#
public enum EventType
{
    None,
    Movie,
    Concert,
    Sports,
    [Description("City Tour")]
    CityTour
}
```

#### There are more useful converters in this package you can use

* __General__
  * EqualsConverter _(requires additional property)_
  * InvertedBoolConverter
  * IsNotNullConverter
  * IsNullConverter
  * EnumDescriptionConverter
  * BoolToObjectConverter <sup>[[Read more]](#booltoobjectconverter)</sup> _(requires additional properties)_ 

* __Image__
  * ByteArrayToImageConverter <sup>[[Read more]](#bytearraytoimageconverter)</sup>
  
* __Number__
  * EmptyToNullNumberConverter <sup>[[Read more]](#emptyto_converter)</sup>
  * EmptyToZeroConverter <sup>[[Read more]](#emptyto_converter)</sup> _(do not use for nullable properties)_
  * IsPositiveConverter
  * IsNegativeConverter
  * IsNonPositiveConverter
  * IsNonNegativeConverter
  * IsLesserThanConverter _(requires additional property)_
  * IsLesserOrEqualThanConverter _(requires additional property)_
  * IsGreaterThanConverter _(requires additional property)_
  * IsGreaterOrEqualThanConverter _(requires additional property)_  
  * IsInRangeConverter _(requires additional properties)_  
  
* __String__
  * SubstringConverter <sup>[[Read more]](#substringconverter)</sup> _(optional property)_
  * ToLowerCaseConverter
  * ToUpperCaseConverterer
  * IsNonNullOrWhitespaceConverter <sup>A collaboration from [[ronymesquita]](https://github.com/ronymesquita)</sup> 

## More examples

```XML
<Label>
    <Label.FormattedText>
        <FormattedString>
            <Span Text="Is equal to 10.5: " />
            <Span.Text>
                <Binding Text="{Binding Number, Converter={conv:EqualsConverter CompareTo=10.0}}" />
			  </Span.Text>
        </FormattedString>
    </Label.FormattedText>
</Label>

<Label>
    <Label.FormattedText>
        <FormattedString>
            <Span Text="Is non negative: " />
            <Span Text="{Binding YourNumber, Converter={conv:IsNonNegativeConverter}}" />
        </FormattedString>
    </Label.FormattedText>
</Label>

<Label>
    <Label.FormattedText>
        <FormattedString>
            <Span Text="Is Null: " />
            <Span Text="{Binding YourNulleableObject, Converter={conv:IsNullConverter}}" />
        </FormattedString>
    </Label.FormattedText>
</Label>
```

## Detailed information

#### BoolToObjectConverter
This converter defines two properties `IfTrue` and `IfFalse` of type `object`. These properties represent the values you want to be returned depending on the boolean value of the bindable property you are using.

#### ByteArrayToImageConverter
For some reason I was required once to retreive byte array from images. After a couple of hours looking for a solution and trying out some approaches I found at __Stack Overflow__ I realized there wasn't an easy way to do it. So I decided to keep my `ItemsSource` as `byte[]` and then use a converter to bind it in my XAML. So that's it.

#### EmptyTo_Converter

When binding an entry to a numeric property, deleting entry's text on the UI doesn't update the target property.
__Ex:__ If the entry value is `123` and you start deleting, in some point the value will be `1` for both UI and view model. If you continue deleting the text on the UI will be an empty string however, binded property in view model stills `1`. By using these converters if you clear the entry, your binded property in view model will be `null` or `0`, depending of which converter is been used.

#### SubstringConverter

Truncates the input string to the length provided in `ConverterParameter` or to 50 characters if no value was provided. Also appends three dots if input's lenght is greater than provided length.

# Good luck!
