# how-to-swipe-item-in-.net-maui-accordion

This sample demonstrates how to enable swipe actions on generated items inside a Syncfusion `SfAccordion` control in a .NET MAUI application. It shows a practical pattern where each generated `AccordionItem` header is wrapped in a `SwipeView`, allowing per-item swipe commands such as "Favourite". The sample is adapted from the project files in this repository and follows the same conceptual approach as the Syncfusion documentation.

Reference (official UG): [Getting Started with MAUI Accordion](https://help.syncfusion.com/maui/accordion/getting-started)

## Overview

Many accordion implementations generate their child items from a collection using `BindableLayout.ItemsSource`. When you need per-item gestures — for example, a swipe-to-favourite action — you can place a `SwipeView` inside the `AccordionItem.Header`. The `SwipeView` can contain `SwipeItems` that bind to commands on the page's `BindingContext` and receive the current item as the `CommandParameter`.

This repository includes a working example using `BindableLayout.ItemTemplate` that produces `AccordionItem` instances. Each header uses a `SwipeView` whose `SwipeItem` calls a command declared on the `SfAccordion`'s page (referenced by name via `{x:Reference accordion}`).

Key points
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

## How it works

1. The page sets its `BindingContext` to an `ItemInfoRepository` (a simple ViewModel exposing an `Info` collection).
2. `SfAccordion` uses `BindableLayout.ItemsSource` to iterate the `Info` collection and create an `AccordionItem` for every element.
3. The `AccordionItem.Header` contains a `SwipeView` which declares swipe actions (`SwipeItems`). Each `SwipeItem` binds to `FavouriteCommand` on the page-level `BindingContext` using `{x:Reference accordion}` to reach the control's BindingContext.
4. `CommandParameter="{Binding .}"` passes the current item to the command so the handler knows which item was swiped.

### Conclusion

I hope you enjoyed learning about how to enable swipe actions in .NET MAUI Accordion(SfAccordion).

You can refer to our [.NET MAUI Accordion](https://www.syncfusion.com/maui-controls/maui-accordion) feature tour page to know about its other groundbreaking feature representations. You can also explore our [.NET MAUI Accordion documentation](https://help.syncfusion.com/maui/accordion/getting-started) to understand how to present and manipulate data.

For current customers, you can check out our components from the [License and Downloads](https://www.syncfusion.com/account/login) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our other controls.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our [support forums](https://www.syncfusion.com/forums/), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!

