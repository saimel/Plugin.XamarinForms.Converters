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
            
<Label Text="{Binding Text, Converter={conv:SubstringConverter}, ConverterParameter=35}" />

<Entry Text="{Binding Number, Mode=TwoWay, Converter={conv:EmptyStringToZeroConverter}}" Keyboard="Numeric" />

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

__Notes:__ 

1. `SubstringConverter` truncates the input string to the length provided in `ConverterParameter` or to 50 characters if no value was provided and appends three dots if input lenght is greater than provided length.
2. `EmptyStringToZeroConverter` will replace empty string with `0` if `BindingMode` is `TwoWay`. 


#### There are more useful converters in this package you can use

* __General__
  * EqualsConverter _(required parameter)_
  * InvertedBoolConverter
  * IsNotNullConverter
  * IsNullConverter
  * EnumDescriptionConverter
* __Number__
  * IsPositiveConverter
  * IsNegativeConverter
  * IsNonPositiveConverter
  * IsNonNegativeConverter
  * IsLesserThanConverter _(required parameter)_
  * IsLesserOrEqualThanConverter _(required parameter)_
  * IsGreaterThanConverter _(required parameter)_
  * IsGreaterOrEqualThanConverter _(required parameter)_
* __String__
  * SubstringConverter _(optional parameter)_
  * ToLowerCaseConverter
  * ToUpperCaseConverter
  * EmptyStringToZeroConverter

## More examples

```XML
<Label>
    <Label.FormattedText>
        <FormattedString>
            <Span Text="Is equal to 10.5: " />
            <Span.Text>
                <Binding Path="Number" Converter="{conv:EqualsConverter}"> 
                    <Binding.ConverterParameter>
                        <x:Double>10.5</x:Double>
                    </Binding.ConverterParameter>
                </Binding>
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
