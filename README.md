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
```

And then you can use it on this way:

```XML
<Entry Text="{Binding Text, Mode=TwoWay}" TextColor="DimGray" Placeholder="Enter a text" Keyboard="Text" />
            
<Label Text="{Binding Text, Converter={conv:ToLowerCaseConverter}}" />
            
<Label Text="{Binding Text, Converter={conv:ToUpperCaseConverter}}" />
```

&nbsp;

#### There are more useful converters in this package you can use

* __General__
  * EqualsConverter
  * InvertedBoolConverter
  * IsNotNullConverter
  * IsNullConverter
* __Number__
  * IsPositiveConverter
  * IsNegativeConverter
  * IsNonPositiveConverter
  * IsNonNegativeConverter
  * IsLesserThanConverter
  * IsLesserOrEqualThanConverter
  * IsGreaterThanConverter
  * IsGreaterOrEqualThanConverter
* __String__
  * ToLowerCaseConverter
  * ToUpperCaseConverter

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