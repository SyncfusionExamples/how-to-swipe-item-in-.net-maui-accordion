# how-to-swipe-item-in-.net-maui-accordion

**Repository Description**  
This repository contains a .NET MAUI sample that demonstrates how to enable **swipe actions** on generated items inside the Syncfusion **SfAccordion** control.

The sample shows a practical pattern where each generated `AccordionItem` header is wrapped in a `SwipeView`, enabling per‑item swipe commands such as **Favourite**. The approach is aligned with the Syncfusion .NET MAUI Accordion guidance and uses MVVM‑friendly command binding.

## Project Overview
The purpose of this project is to help developers understand how to add swipe gestures to accordion items that are generated dynamically using `BindableLayout.ItemsSource`. This technique is useful when building interactive UIs that require per‑item actions (for example, marking items as favourites) without cluttering the main content area.

## Features
- Integration of Syncfusion .NET MAUI **SfAccordion**  
- Generate accordion items using `BindableLayout.ItemsSource`  
- Enable swipe gestures on accordion headers using `SwipeView`  
- Bind swipe actions to page‑level commands  
- Pass the current item as a `CommandParameter`  

## Prerequisites
Ensure the following requirements are met before running this project:
- Visual Studio 2022  
- .NET SDK compatible with .NET MAUI  

## Installation and Running the Project
1. Clone or download this repository to your local machine.
2. Open the solution in Visual Studio 2022.
3. Restore NuGet packages by rebuilding the solution.
4. Build and run the project on a supported .NET MAUI platform.

## About Sample

This sample demonstrates how to enable swipe actions on generated items inside a Syncfusion `SfAccordion` control in a .NET MAUI application. It shows a practical pattern where each generated `AccordionItem` header is wrapped in a `SwipeView`, allowing per-item swipe commands such as "Favourite". The sample is adapted from the project files in this repository and follows the same conceptual approach as the Syncfusion documentation.

### Key points
- Use `BindableLayout.ItemsSource` on `SfAccordion` to bind a collection.
- Wrap the header content in a `SwipeView` and declare `SwipeItems` for left/right swipe actions.
- Use `Command` and `CommandParameter` to call page-level commands and pass the current data item.

## XAML

Below are the relevant parts of `MainPage.xaml` used in this sample. The XAML shows how each `AccordionItem`'s header contains a `SwipeView` with a left `SwipeItem` named "Favourite" which binds to a command on the page's `BindingContext`:

```
<ContentPage.BindingContext>
    <local:ItemInfoRepository />
</ContentPage.BindingContext>

<ContentPage.Content>
    <accordion:SfAccordion x:Name="accordion"
                            BindableLayout.ItemsSource="{Binding Info}"
                            Margin="0,50,0,0"
                            ExpandMode="SingleOrNone">
        <BindableLayout.ItemTemplate>
            <DataTemplate>
                <accordion:AccordionItem HeaderBackground="{Binding HeaderColor}">
                    <accordion:AccordionItem.Header>
                        <SwipeView BackgroundColor="Transparent">
                            <SwipeView.LeftItems>
                                <SwipeItems>
                                    <SwipeItem Text="Favourite"
                                                BackgroundColor="#98acf8"
                                                Command="{Binding Path=BindingContext.FavouriteCommand, Source={x:Reference accordion}}"
                                                CommandParameter="{Binding .}" />
                                </SwipeItems>
                            </SwipeView.LeftItems>
                            <Grid>
                                <Label TextColor="#495F6E"
                                        Text="{Binding Name}"
                                        VerticalOptions="Center"
                                        HorizontalOptions="Center"
                                        HeightRequest="50"
                                        VerticalTextAlignment="Center" />
                            </Grid>
                        </SwipeView>
                    </accordion:AccordionItem.Header>
                    <accordion:AccordionItem.Content>
                        <Grid BackgroundColor="#e8e8e8"
                                Padding="10">
                            <Label Text="{Binding Description}"
                                    LineHeight="1.2"
                                    VerticalOptions="Center" />
                        </Grid>
                    </accordion:AccordionItem.Content>
                </accordion:AccordionItem>
            </DataTemplate>
        </BindableLayout.ItemTemplate>
    </accordion:SfAccordion>
</ContentPage.Content>
```

### How it works

1. The page sets its `BindingContext` to an `ItemInfoRepository` (a simple ViewModel exposing an `Info` collection).
2. `SfAccordion` uses `BindableLayout.ItemsSource` to iterate the `Info` collection and create an `AccordionItem` for every element.
3. The `AccordionItem.Header` contains a `SwipeView` which declares swipe actions (`SwipeItems`). Each `SwipeItem` binds to `FavouriteCommand` on the page-level `BindingContext` using `{x:Reference accordion}` to reach the control's BindingContext.
4. `CommandParameter="{Binding .}"` passes the current item to the command so the handler knows which item was swiped.

## Usage
Run the application to see the SfAccordion populated from the `Info` collection in the ViewModel.  
Swipe left on an accordion header to reveal the **Favourite** action. When triggered, the swipe item invokes a command defined on the page’s BindingContext and passes the current item as the command parameter.

This pattern is suitable for:
- Swipe‑to‑favourite scenarios  
- Contextual item actions  
- Clean, gesture‑driven user interfaces  

## Documentation
- General Syncfusion documentation:
https://help.syncfusion.com/
- .NET MAUI Introduction:
https://help.syncfusion.com/maui/introduction/overview
- .NET MAUI Accordion Getting Started:
https://help.syncfusion.com/maui/accordion/getting-started

## Additional Resources
- Syncfusion MAUI Accordion feature tour:
https://www.syncfusion.com/maui-controls/maui-accordion

## Troubleshooting
- Ensure SwipeView is placed inside the AccordionItem.Header.
- Verify that FavouriteCommand exists on the page’s BindingContext.
- Rebuild the solution if swipe gestures are not recognized.
- Check output logs for binding or gesture‑related errors.

## Conclusion

I hope you enjoyed learning about how to enable swipe actions in .NET MAUI Accordion(SfAccordion).

You can refer to our [.NET MAUI Accordion](https://www.syncfusion.com/maui-controls/maui-accordion) feature tour page to know about its other groundbreaking feature representations. You can also explore our [.NET MAUI Accordion documentation](https://help.syncfusion.com/maui/accordion/getting-started) to understand how to present and manipulate data.

For current customers, you can check out our components from the [License and Downloads](https://www.syncfusion.com/account/login) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our other controls.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our [support forums](https://www.syncfusion.com/forums/), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!

