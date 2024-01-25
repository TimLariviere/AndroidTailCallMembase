module Program

[<NoEquality; NoComparison>]
type Widget(name: string) = struct end
[<NoEquality; NoComparison>]
type WidgetBuilder(name: string, data: obj) =
    struct
        member this.Compile() = Widget(name)   
    end
    
[<NoEquality; NoComparison>]
type CollectionBuilder =
    val name: string
    new (name: string) = { name = name }
    
    member inline this.Yield(widgetBuilder: WidgetBuilder) =
        [| widgetBuilder.Compile() |]
    
    member inline _.Combine(a: Widget array, b: Widget array) : Widget array =
        Array.append a b

    member inline _.Zero() : Widget array = [||]

    member inline _.Delay([<InlineIfLambda>] f) : Widget array = f()
    
    member inline x.Run(c: Widget array) =
        WidgetBuilder(x.name, c)

[<Measure>] type binding
[<NoEquality; NoComparison>]
type ComponentContext() = class end
[<NoEquality; NoComparison>]
type ComponentBody = delegate of ComponentContext -> struct (ComponentContext * Widget)

[<NoEquality; NoComparison>]
type ComponentBodyBuilder<'what> = delegate of bindings: int<binding> * context: ComponentContext -> struct (int<binding> * WidgetBuilder)

[<NoEquality; NoComparison>]
type ComponentBuilder() =
    member inline this.Yield(widgetBuilder: WidgetBuilder) =
        ComponentBodyBuilder(fun bindings ctx -> struct (bindings, widgetBuilder))

    member inline this.Combine([<InlineIfLambda>] a: ComponentBodyBuilder<'what>, [<InlineIfLambda>] b: ComponentBodyBuilder<'what>) =
        ComponentBodyBuilder(fun bindings ctx ->
            let struct (bindingsA, _) = a.Invoke(bindings, ctx) // discard the previous widget in the chain but we still need to count the bindings
            let struct (bindingsB, resultB) = b.Invoke(bindings, ctx)

            // Calculate the total number of bindings between A and B
            let resultBindings = (bindingsA + bindingsB) - bindings

            struct (resultBindings, resultB))

    member inline this.Delay([<InlineIfLambda>] fn: unit -> ComponentBodyBuilder<'what>) =
        ComponentBodyBuilder(fun bindings ctx ->
            let sub = fn()
            sub.Invoke(bindings, ctx))

    member inline this.Run([<InlineIfLambda>] body: ComponentBodyBuilder<'what>) =
        let compiledBody =
            ComponentBody(fun ctx ->
                let struct (_, result) = body.Invoke(0<binding>, ctx)
                struct (ctx, result.Compile()))

        WidgetBuilder("component", compiledBody)
        

let main () =
    ComponentBuilder() {
        CollectionBuilder("coll") {
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            
            
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            
            
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            WidgetBuilder("1", null)
            
        }
    }