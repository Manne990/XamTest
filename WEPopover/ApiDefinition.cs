using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace WEPopover
{
    // @interface WEPopover (UIBarButtonItem)
    [Category]
    [BaseType (typeof(UIBarButtonItem))]
    interface UIBarButtonItem_WEPopover
    {
        // -(CGRect)weFrameInView:(UIView *)v;
        [Export ("weFrameInView:")]
        CGRect WeFrameInView (UIView v);

        // -(UIView *)weSuperview;
        [Export ("weSuperview")]
        UIView WeSuperview ();
    }

    // @interface WEBlockingGestureRecognizer : UIGestureRecognizer
    [BaseType (typeof(UIGestureRecognizer))]
    interface WEBlockingGestureRecognizer
    {
    }

    // @interface WEPopoverContainerViewProperties : NSObject
    [BaseType (typeof(NSObject))]
    interface WEPopoverContainerViewProperties
    {
        // @property (assign, nonatomic) UIEdgeInsets backgroundMargins;
        [Export ("backgroundMargins", ArgumentSemantic.Assign)]
        UIEdgeInsets BackgroundMargins { get; set; }

        // @property (assign, nonatomic) UIEdgeInsets contentMargins;
        [Export ("contentMargins", ArgumentSemantic.Assign)]
        UIEdgeInsets ContentMargins { get; set; }

        // @property (assign, nonatomic) NSInteger topBgCapSize;
        [Export ("topBgCapSize")]
        nint TopBgCapSize { get; set; }

        // @property (assign, nonatomic) NSInteger leftBgCapSize;
        [Export ("leftBgCapSize")]
        nint LeftBgCapSize { get; set; }

        // @property (assign, nonatomic) CGFloat arrowMargin;
        [Export ("arrowMargin")]
        nfloat ArrowMargin { get; set; }

        // @property (nonatomic, strong) UIColor * maskBorderColor;
        [Export ("maskBorderColor", ArgumentSemantic.Strong)]
        UIColor MaskBorderColor { get; set; }

        // @property (assign, nonatomic) CGFloat maskBorderWidth;
        [Export ("maskBorderWidth")]
        nfloat MaskBorderWidth { get; set; }

        // @property (assign, nonatomic) CGFloat maskCornerRadius;
        [Export ("maskCornerRadius")]
        nfloat MaskCornerRadius { get; set; }

        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export ("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIImage * upArrowImage;
        [Export ("upArrowImage", ArgumentSemantic.Strong)]
        UIImage UpArrowImage { get; set; }

        // @property (nonatomic, strong) UIImage * downArrowImage;
        [Export ("downArrowImage", ArgumentSemantic.Strong)]
        UIImage DownArrowImage { get; set; }

        // @property (nonatomic, strong) UIImage * leftArrowImage;
        [Export ("leftArrowImage", ArgumentSemantic.Strong)]
        UIImage LeftArrowImage { get; set; }

        // @property (nonatomic, strong) UIImage * rightArrowImage;
        [Export ("rightArrowImage", ArgumentSemantic.Strong)]
        UIImage RightArrowImage { get; set; }

        // @property (nonatomic, strong) UIImage * bgImage;
        [Export ("bgImage", ArgumentSemantic.Strong)]
        UIImage BgImage { get; set; }

        // @property (nonatomic, strong) NSString * upArrowImageName;
        [Export ("upArrowImageName", ArgumentSemantic.Strong)]
        string UpArrowImageName { get; set; }

        // @property (nonatomic, strong) NSString * downArrowImageName;
        [Export ("downArrowImageName", ArgumentSemantic.Strong)]
        string DownArrowImageName { get; set; }

        // @property (nonatomic, strong) NSString * leftArrowImageName;
        [Export ("leftArrowImageName", ArgumentSemantic.Strong)]
        string LeftArrowImageName { get; set; }

        // @property (nonatomic, strong) NSString * rightArrowImageName;
        [Export ("rightArrowImageName", ArgumentSemantic.Strong)]
        string RightArrowImageName { get; set; }

        // @property (nonatomic, strong) NSString * bgImageName;
        [Export ("bgImageName", ArgumentSemantic.Strong)]
        string BgImageName { get; set; }
    }

    // @protocol WEPopoverContainerViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface WEPopoverContainerViewDelegate
    {
        // @required -(CGRect)popoverContainerView:(WEPopoverContainerView *)view willChangeFrame:(CGRect)newFrame;
        [Abstract]
        [Export ("popoverContainerView:willChangeFrame:")]
        CGRect WillChangeFrame (WEPopoverContainerView view, CGRect newFrame);
    }

    // @interface WEPopoverContainerView : UIView
    [BaseType (typeof(UIView))]
    interface WEPopoverContainerView
    {
        [Wrap ("WeakDelegate")]
        [NullAllowed]
        WEPopoverContainerViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<WEPopoverContainerViewDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) UIPopoverArrowDirection arrowDirection;
        [Export ("arrowDirection")]
        UIPopoverArrowDirection ArrowDirection { get; }

        // @property (nonatomic, strong) UIView * contentView;
        [Export ("contentView", ArgumentSemantic.Strong)]
        UIView ContentView { get; set; }

        // @property (getter = isArrowCollapsed, assign, nonatomic) BOOL arrowCollapsed;
        [Export ("arrowCollapsed")]
        bool ArrowCollapsed { [Bind ("isArrowCollapsed")] get; set; }

        // -(id)initWithSize:(CGSize)theSize anchorRect:(CGRect)anchorRect displayArea:(CGRect)displayArea permittedArrowDirections:(UIPopoverArrowDirection)permittedArrowDirections properties:(WEPopoverContainerViewProperties *)properties;
        [Export ("initWithSize:anchorRect:displayArea:permittedArrowDirections:properties:")]
        IntPtr Constructor (CGSize theSize, CGRect anchorRect, CGRect displayArea, UIPopoverArrowDirection permittedArrowDirections, WEPopoverContainerViewProperties properties);

        // -(void)updatePositionWithSize:(CGSize)theSize anchorRect:(CGRect)anchorRect displayArea:(CGRect)displayArea permittedArrowDirections:(UIPopoverArrowDirection)permittedArrowDirections;
        [Export ("updatePositionWithSize:anchorRect:displayArea:permittedArrowDirections:")]
        void UpdatePositionWithSize (CGSize theSize, CGRect anchorRect, CGRect displayArea, UIPopoverArrowDirection permittedArrowDirections);

        // -(CGRect)calculatedFrame;
        [Export ("calculatedFrame")]
        //[Verify (MethodToProperty)]
        CGRect CalculatedFrame { get; }

        // -(void)setContentView:(UIView *)v withAnimationDuration:(NSTimeInterval)duration;
        [Export ("setContentView:withAnimationDuration:")]
        void SetContentView (UIView v, double duration);

        // -(void)setFrame:(CGRect)frame sendNotification:(BOOL)sendNotification;
        [Export ("setFrame:sendNotification:")]
        void SetFrame (CGRect frame, bool sendNotification);
    }

    // @protocol WETouchableViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface WETouchableViewDelegate
    {
        // @optional -(void)viewWasTouched:(WETouchableView *)view;
        [Export ("viewWasTouched:")]
        void ViewWasTouched (WETouchableView view);

        // @optional -(CGRect)fillRectForView:(WETouchableView *)view;
        [Export ("fillRectForView:")]
        CGRect FillRectForView (WETouchableView view);
    }

    // @interface WETouchableView : UIView
    [BaseType (typeof(UIView))]
    interface WETouchableView
    {
        // @property (assign, nonatomic) BOOL touchForwardingDisabled;
        [Export ("touchForwardingDisabled")]
        bool TouchForwardingDisabled { get; set; }

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        WETouchableViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<WETouchableViewDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (copy, nonatomic) NSArray * passthroughViews;
        [Export ("passthroughViews", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] PassthroughViews { get; set; }

        // @property (nonatomic, strong) UIView * fillView;
        [Export ("fillView", ArgumentSemantic.Strong)]
        UIView FillView { get; set; }

        // -(void)setFillColor:(UIColor *)fillColor;
        [Export ("setFillColor:")]
        void SetFillColor (UIColor fillColor);
    }

    [Static]
    //[Verify (ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const WEPopoverControllerWillShowNotification;
        [Field ("WEPopoverControllerWillShowNotification", "__Internal")]
        NSString WEPopoverControllerWillShowNotification { get; }

        // extern NSString *const WEPopoverControllerDidDismissNotification;
        [Field ("WEPopoverControllerDidDismissNotification", "__Internal")]
        NSString WEPopoverControllerDidDismissNotification { get; }
    }

    // @protocol WEPopoverControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface WEPopoverControllerDelegate
    {
        // @optional -(void)popoverControllerDidDismissPopover:(WEPopoverController *)popoverController;
        [Export ("popoverControllerDidDismissPopover:")]
        void PopoverControllerDidDismissPopover (WEPopoverController popoverController);

        // @optional -(BOOL)popoverControllerShouldDismissPopover:(WEPopoverController *)popoverController;
        [Export ("popoverControllerShouldDismissPopover:")]
        bool PopoverControllerShouldDismissPopover (WEPopoverController popoverController);

        // @optional -(void)popoverController:(WEPopoverController *)popoverController willRepositionPopoverToRect:(CGRect *)rect inView:(UIView **)view;
        [Export ("popoverController:willRepositionPopoverToRect:inView:")]
        unsafe void PopoverController (WEPopoverController popoverController, CGRect rect, out UIView view);
        //unsafe void PopoverController (WEPopoverController popoverController, CGRect* rect, out UIView view);

        // @optional -(CGRect)displayAreaForPopoverController:(WEPopoverController *)popoverController relativeToView:(UIView *)parentView;
        [Export ("displayAreaForPopoverController:relativeToView:")]
        CGRect DisplayAreaForPopoverController (WEPopoverController popoverController, UIView parentView);

        // @optional -(CGRect)backgroundAreaForPopoverController:(WEPopoverController *)popoverController relativeToView:(UIView *)parentView;
        [Export ("backgroundAreaForPopoverController:relativeToView:")]
        CGRect BackgroundAreaForPopoverController (WEPopoverController popoverController, UIView parentView);

        // @optional -(UIView *)backgroundViewForPopoverController:(WEPopoverController *)popoverController;
        [Export ("backgroundViewForPopoverController:")]
        UIView BackgroundViewForPopoverController (WEPopoverController popoverController);
    }

    // typedef void (^WEPopoverCompletionBlock)();
    delegate void WEPopoverCompletionBlock ();

    // typedef void (^WEPopoverTransitionBlock)(WEPopoverTransitionType, BOOL);
    delegate void WEPopoverTransitionBlock (WEPopoverTransitionType arg0, bool arg1);

    // @interface WEPopoverController : NSObject
    [BaseType (typeof(NSObject))]
    interface WEPopoverController
    {
        // @property (nonatomic, strong) UIViewController * contentViewController;
        [Export ("contentViewController", ArgumentSemantic.Strong)]
        UIViewController ContentViewController { get; set; }

        // @property (readonly, getter = isPresenting, nonatomic) BOOL presenting;
        [Export ("presenting")]
        bool Presenting { [Bind ("isPresenting")] get; }

        // @property (readonly, getter = isDismissing, nonatomic) BOOL dismissing;
        [Export ("dismissing")]
        bool Dismissing { [Bind ("isDismissing")] get; }

        // @property (readonly, nonatomic, weak) UIView * _Nullable presentedFromView;
        [NullAllowed, Export ("presentedFromView", ArgumentSemantic.Weak)]
        UIView PresentedFromView { get; }

        // @property (readonly, assign, nonatomic) CGRect presentedFromRect;
        [Export ("presentedFromRect", ArgumentSemantic.Assign)]
        CGRect PresentedFromRect { get; }

        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export ("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (readonly, getter = isPopoverVisible, nonatomic) BOOL popoverVisible;
        [Export ("popoverVisible")]
        bool PopoverVisible { [Bind ("isPopoverVisible")] get; }

        // @property (readonly, nonatomic) UIPopoverArrowDirection popoverArrowDirection;
        [Export ("popoverArrowDirection")]
        UIPopoverArrowDirection PopoverArrowDirection { get; }

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        WEPopoverControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<WEPopoverControllerDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) CGSize popoverContentSize;
        [Export ("popoverContentSize", ArgumentSemantic.Assign)]
        CGSize PopoverContentSize { get; set; }

        // @property (nonatomic, strong) WEPopoverContainerViewProperties * containerViewProperties;
        [Export ("containerViewProperties", ArgumentSemantic.Strong)]
        WEPopoverContainerViewProperties ContainerViewProperties { get; set; }

        // @property (nonatomic, strong) id<NSObject> context;
        [Export ("context", ArgumentSemantic.Strong)]
        NSObject Context { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable parentView;
        [NullAllowed, Export ("parentView", ArgumentSemantic.Weak)]
        UIView ParentView { get; set; }

        // @property (copy, nonatomic) NSArray * passthroughViews;
        [Export ("passthroughViews", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] PassthroughViews { get; set; }

        // @property (assign, nonatomic) WEPopoverAnimationType animationType;
        [Export ("animationType", ArgumentSemantic.Assign)]
        WEPopoverAnimationType AnimationType { get; set; }

        // @property (assign, nonatomic) NSTimeInterval primaryAnimationDuration;
        [Export ("primaryAnimationDuration")]
        double PrimaryAnimationDuration { get; set; }

        // @property (assign, nonatomic) NSTimeInterval secundaryAnimationDuration;
        [Export ("secundaryAnimationDuration")]
        double SecundaryAnimationDuration { get; set; }

        // @property (assign, nonatomic) UIEdgeInsets popoverLayoutMargins;
        [Export ("popoverLayoutMargins", ArgumentSemantic.Assign)]
        UIEdgeInsets PopoverLayoutMargins { get; set; }

        // @property (copy, nonatomic) WEPopoverTransitionBlock transitionBlock;
        [Export ("transitionBlock", ArgumentSemantic.Copy)]
        WEPopoverTransitionBlock TransitionBlock { get; set; }

        // @property (copy, nonatomic) WEPopoverCompletionBlock afterDismissBlock;
        [Export ("afterDismissBlock", ArgumentSemantic.Copy)]
        WEPopoverCompletionBlock AfterDismissBlock { get; set; }

        // @property (assign, nonatomic) Class backgroundViewClass;
        [Export ("backgroundViewClass", ArgumentSemantic.Assign)]
        Class BackgroundViewClass { get; set; }

        // +(WEPopoverContainerViewProperties *)defaultContainerViewProperties;
        // +(void)setDefaultContainerViewProperties:(WEPopoverContainerViewProperties *)properties;
        [Static]
        [Export ("defaultContainerViewProperties")]
        //[Verify (MethodToProperty)]
        WEPopoverContainerViewProperties DefaultContainerViewProperties { get; set; }

        // +(BOOL)isAnyPopoverVisible;
        [Static]
        [Export ("isAnyPopoverVisible")]
        bool IsAnyPopoverVisible ();

        // -(id)initWithContentViewController:(UIViewController *)theContentViewController;
        [Export ("initWithContentViewController:")]
        IntPtr Constructor (UIViewController theContentViewController);

        // -(void)setContentViewController:(UIViewController *)contentViewController animated:(BOOL)animated;
        [Export ("setContentViewController:animated:")]
        void SetContentViewController (UIViewController contentViewController, bool animated);

        // -(void)dismissPopoverAnimated:(BOOL)animated;
        [Export ("dismissPopoverAnimated:")]
        void DismissPopoverAnimated (bool animated);

        // -(void)dismissPopoverAnimated:(BOOL)animated completion:(WEPopoverCompletionBlock)completion;
        [Export ("dismissPopoverAnimated:completion:")]
        void DismissPopoverAnimated (bool animated, WEPopoverCompletionBlock completion);

        // -(void)presentPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
        [Export ("presentPopoverFromRect:inView:permittedArrowDirections:animated:")]
        void PresentPopoverFromRect (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated);

        // -(void)presentPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated completion:(WEPopoverCompletionBlock)completion;
        [Export ("presentPopoverFromRect:inView:permittedArrowDirections:animated:completion:")]
        void PresentPopoverFromRect (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated, WEPopoverCompletionBlock completion);

        // -(void)presentPopoverFromBarButtonItem:(UIBarButtonItem *)item permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
        [Export ("presentPopoverFromBarButtonItem:permittedArrowDirections:animated:")]
        void PresentPopoverFromBarButtonItem (UIBarButtonItem item, UIPopoverArrowDirection arrowDirections, bool animated);

        // -(void)presentPopoverFromBarButtonItem:(UIBarButtonItem *)item permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated completion:(WEPopoverCompletionBlock)completion;
        [Export ("presentPopoverFromBarButtonItem:permittedArrowDirections:animated:completion:")]
        void PresentPopoverFromBarButtonItem (UIBarButtonItem item, UIPopoverArrowDirection arrowDirections, bool animated, WEPopoverCompletionBlock completion);

        // -(void)repositionForContentViewController:(UIViewController *)vc animated:(BOOL)animated;
        [Export ("repositionForContentViewController:animated:")]
        void RepositionForContentViewController (UIViewController vc, bool animated);

        // -(void)repositionPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
        [Export ("repositionPopoverFromRect:inView:permittedArrowDirections:animated:")]
        void RepositionPopoverFromRect (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated);

        // -(void)repositionPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated completion:(WEPopoverCompletionBlock)completion;
        [Export ("repositionPopoverFromRect:inView:permittedArrowDirections:animated:completion:")]
        void RepositionPopoverFromRect (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated, WEPopoverCompletionBlock completion);
    }

    // @protocol WEPopoverParentView
    [Protocol, Model]
    interface WEPopoverParentView
    {
        // @optional -(CGRect)displayAreaForPopover;
        [Export ("displayAreaForPopover")]
        //[Verify (MethodToProperty)]
        CGRect DisplayAreaForPopover { get; }
    }
}

/*
namespace WEPopover
{
	// @interface WEPopover (UIBarButtonItem)
	[Category]
	[BaseType (typeof(UIBarButtonItem))]
	interface UIBarButtonItem_WEPopover
	{
		// -(CGRect)frameInView:(UIView *)v;
		[Export ("frameInView:")]
		CGRect FrameInView (UIView v);

		// -(UIView *)superview;
		[Export ("superview")]
		UIView Superview ();
	}

	// @interface WEBlockingGestureRecognizer : UIGestureRecognizer
	[BaseType (typeof(UIGestureRecognizer), Name = "WEBlockingGestureRecognizer")]
	interface BlockingGestureRecognizer
	{
	}

	// @interface WEPopoverContainerViewProperties : NSObject
	[BaseType (typeof(NSObject), Name = "WEPopoverContainerViewProperties")]
	interface PopoverContainerViewProperties
	{
		// @property (assign, nonatomic) CGFloat leftBgMargin;
		[Export ("leftBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat LeftBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat rightBgMargin;
		[Export ("rightBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat RightBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat topBgMargin;
		[Export ("topBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat TopBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat bottomBgMargin;
		[Export ("bottomBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat BottomBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat leftContentMargin;
		[Export ("leftContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat LeftContentMargin { get; set; }

		// @property (assign, nonatomic) CGFloat rightContentMargin;
		[Export ("rightContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat RightContentMargin { get; set; }

		// @property (assign, nonatomic) CGFloat topContentMargin;
		[Export ("topContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat TopContentMargin { get; set; }

		// @property (assign, nonatomic) CGFloat bottomContentMargin;
		[Export ("bottomContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat BottomContentMargin { get; set; }

		// @property (assign, nonatomic) NSInteger topBgCapSize;
		[Export ("topBgCapSize", ArgumentSemantic.UnsafeUnretained)]
		nint TopBackgroundCapSize { get; set; }

		// @property (assign, nonatomic) NSInteger leftBgCapSize;
		[Export ("leftBgCapSize", ArgumentSemantic.UnsafeUnretained)]
		nint LeftBackgroundCapSize { get; set; }

		// @property (assign, nonatomic) CGFloat arrowMargin;
		[Export ("arrowMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat ArrowMargin { get; set; }

		// @property (nonatomic, strong) UIColor * maskBorderColor;
		[Export ("maskBorderColor", ArgumentSemantic.Retain)]
		UIColor MaskBorderColor { get; set; }

		// @property (assign, nonatomic) CGFloat maskBorderWidth;
		[Export ("maskBorderWidth", ArgumentSemantic.UnsafeUnretained)]
		nfloat MaskBorderWidth { get; set; }

		// @property (assign, nonatomic) CGFloat maskCornerRadius;
		[Export ("maskCornerRadius", ArgumentSemantic.UnsafeUnretained)]
		nfloat MaskCornerRadius { get; set; }

		// @property (assign, nonatomic) CGSize maskInsets;
		[Export ("maskInsets", ArgumentSemantic.UnsafeUnretained)]
		CGSize MaskInsets { get; set; }

		// @property (nonatomic, strong) UIImage * upArrowImage;
		[Export ("upArrowImage", ArgumentSemantic.Retain)]
		UIImage UpArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * downArrowImage;
		[Export ("downArrowImage", ArgumentSemantic.Retain)]
		UIImage DownArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * leftArrowImage;
		[Export ("leftArrowImage", ArgumentSemantic.Retain)]
		UIImage LeftArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * rightArrowImage;
		[Export ("rightArrowImage", ArgumentSemantic.Retain)]
		UIImage RightArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * bgImage;
		[Export ("bgImage", ArgumentSemantic.Retain)]
		UIImage BackgroundImage { get; set; }

		// @property (nonatomic, strong) NSString * upArrowImageName;
		[Export ("upArrowImageName", ArgumentSemantic.Retain)]
		string UpArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * downArrowImageName;
		[Export ("downArrowImageName", ArgumentSemantic.Retain)]
		string DownArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * leftArrowImageName;
		[Export ("leftArrowImageName", ArgumentSemantic.Retain)]
		string LeftArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * rightArrowImageName;
		[Export ("rightArrowImageName", ArgumentSemantic.Retain)]
		string RightArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * bgImageName;
		[Export ("bgImageName", ArgumentSemantic.Retain)]
		string BackgroundImageName { get; set; }
	}

	interface IPopoverContainerViewDelegate {}

	// @protocol WEPopoverContainerViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "WEPopoverContainerViewDelegate")]
	interface PopoverContainerViewDelegate
	{
		// @required -(CGRect)popoverContainerView:(WEPopoverContainerView *)view willChangeFrame:(CGRect)newFrame;
		[Abstract]
		[Export ("popoverContainerView:willChangeFrame:")]
		CGRect WillChangeFrame (PopoverContainerView view, CGRect newFrame);
	}

	// @interface WEPopoverContainerView : UIView
	[BaseType (typeof(UIView), Name = "WEPopoverContainerView")]

	interface PopoverContainerView
	{
		// @property (nonatomic, weak) id<WEPopoverContainerViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPopoverContainerViewDelegate Delegate { get; set; }

		// @property (readonly, nonatomic) UIPopoverArrowDirection arrowDirection;
		[Export ("arrowDirection")]
		UIPopoverArrowDirection ArrowDirection { get; }

		// @property (nonatomic, strong) UIView * contentView;
		[Export ("contentView", ArgumentSemantic.Retain)]
		UIView ContentView { get; set; }

		// -(id)initWithSize:(CGSize)theSize anchorRect:(CGRect)anchorRect displayArea:(CGRect)displayArea permittedArrowDirections:(UIPopoverArrowDirection)permittedArrowDirections properties:(WEPopoverContainerViewProperties *)properties;
		[Export ("initWithSize:anchorRect:displayArea:permittedArrowDirections:properties:")]
		IntPtr Constructor (CGSize theSize, CGRect anchorRect, CGRect displayArea, UIPopoverArrowDirection permittedArrowDirections, PopoverContainerViewProperties properties);

		// -(void)updatePositionWithSize:(CGSize)theSize anchorRect:(CGRect)anchorRect displayArea:(CGRect)displayArea permittedArrowDirections:(UIPopoverArrowDirection)permittedArrowDirections;
		[Export ("updatePositionWithSize:anchorRect:displayArea:permittedArrowDirections:")]
		void UpdatePosition (CGSize theSize, CGRect anchorRect, CGRect displayArea, UIPopoverArrowDirection permittedArrowDirections);

		// -(CGRect)calculatedFrame;
		[Export ("calculatedFrame")]
		CGRect CalculatedFrame { get; }
	}

	interface ITouchableViewDelegate {}

	// @protocol WETouchableViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "WETouchableViewDelegate")]
	interface TouchableViewDelegate
	{
		// @required -(void)viewWasTouched:(WETouchableView *)view;
		[Abstract]
		[Export ("viewWasTouched:")]
		void ViewWasTouched (TouchableView view);
	}

	// @interface WETouchableView : UIView
	[BaseType (typeof(UIView), Name = "WETouchableView",
		Delegates=new string [] { "Delegate" }, 
		Events=new Type [] {typeof(TouchableViewDelegate)})]
	interface TouchableView
	{
		// @property (assign, nonatomic) BOOL touchForwardingDisabled;
		[Export ("touchForwardingDisabled")]
		bool TouchForwardingDisabled { get; set; }

		// @property (nonatomic, weak) id<WETouchableViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		ITouchableViewDelegate Delegate { get; set; }

		// @property (copy, nonatomic) NSArray * passthroughViews;
		[Export ("passthroughViews", ArgumentSemantic.Copy)]
		NSObject[] PassthroughViews { get; set; }
	}

	interface IPopoverControllerDelegate {}

	// @protocol WEPopoverControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "WEPopoverControllerDelegate")]
	interface PopoverControllerDelegate
	{
		// @optional -(void)popoverControllerDidDismissPopover:(WEPopoverController *)popoverController;
		[Export ("popoverControllerDidDismissPopover:")]
		void DidDismissPopover (PopoverController popoverController);

		// @optional -(BOOL)popoverControllerShouldDismissPopover:(WEPopoverController *)popoverController;
		[Export ("popoverControllerShouldDismissPopover:")]
		bool ShouldDismissPopover (PopoverController popoverController);

		// @optional -(void)popoverController:(WEPopoverController *)popoverController willRepositionPopoverToRect:(CGRect *)rect inView:(UIView **)view;
		[Export ("popoverController:willRepositionPopoverToRect:inView:")]
		void WillRepositionPopover (PopoverController popoverController, ref CGRect rect, ref UIView view);
	}

	// @interface WEPopoverController : NSObject
	[BaseType (typeof(NSObject), Name = "WEPopoverController")]
	interface PopoverController
	{
		// @property (nonatomic, strong) UIViewController * contentViewController;
		[Export ("contentViewController", ArgumentSemantic.Retain)]
		UIViewController ContentViewController { get; set; }

		// @property (readonly, nonatomic, weak) UIView * presentedFromView;
		[Export ("presentedFromView", ArgumentSemantic.Weak)]
		UIView PresentedFromView { get; }

		// @property (readonly, assign, nonatomic) CGRect presentedFromRect;
		[Export ("presentedFromRect", ArgumentSemantic.UnsafeUnretained)]
		CGRect PresentedFromRect { get; }

		// @property (readonly, nonatomic, weak) UIView * view;
		[Export ("view", ArgumentSemantic.Weak)]
		UIView View { get; }

		// @property (nonatomic, strong) UIColor * backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Retain)]
		UIColor BackgroundColor { get; set; }

		// @property (readonly, nonatomic) UIView * backgroundView;
		[Export ("backgroundView")]
		UIView BackgroundView { get; }

		// @property (readonly, getter = isPopoverVisible, nonatomic) BOOL popoverVisible;
		[Export ("popoverVisible")]
		bool PopoverVisible { [Bind ("isPopoverVisible")] get; }

		// @property (readonly, nonatomic) UIPopoverArrowDirection popoverArrowDirection;
		[Export ("popoverArrowDirection")]
		UIPopoverArrowDirection PopoverArrowDirection { get; }

		// @property (nonatomic, weak) id<WEPopoverControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPopoverControllerDelegate Delegate { get; set; }

		// @property (assign, nonatomic) CGSize popoverContentSize;
		[Export ("popoverContentSize", ArgumentSemantic.UnsafeUnretained)]
		CGSize ContentSize { get; set; }

		// @property (nonatomic, strong) WEPopoverContainerViewProperties * containerViewProperties;
		[Export ("containerViewProperties", ArgumentSemantic.Retain)]
		PopoverContainerViewProperties Properties { get; set; }

		// @property (nonatomic, strong) id<NSObject> context;
		[Export ("context", ArgumentSemantic.Retain)]
		NSObject Context { get; set; }

		// @property (nonatomic, weak) UIView * parentView;
		[Export ("parentView", ArgumentSemantic.Weak)]
		UIView ParentView { get; set; }

		// @property (copy, nonatomic) NSArray * passthroughViews;
		[Export ("passthroughViews", ArgumentSemantic.Copy)]
		NSObject[] PassthroughViews { get; set; }

		// @property (assign, nonatomic) UIEdgeInsets popoverLayoutMargins;
		[Export ("popoverLayoutMargins", ArgumentSemantic.UnsafeUnretained)]
		UIEdgeInsets PopoverLayoutMargins { get; set; }

		// +(WEPopoverContainerViewProperties *)defaultContainerViewProperties;
		[Static]
		[Export ("defaultContainerViewProperties")]
		PopoverContainerViewProperties DefaultContainerViewProperties { get; }

		// +(void)setDefaultContainerViewProperties:(WEPopoverContainerViewProperties *)properties;
		[Static]
		[Export ("setDefaultContainerViewProperties:")]
		void SetDefaultContainerViewProperties (PopoverContainerViewProperties properties);

		// -(id)initWithContentViewController:(UIViewController *)theContentViewController;
		[Export ("initWithContentViewController:")]
		IntPtr Constructor (UIViewController theContentViewController);

		// -(void)dismissPopoverAnimated:(BOOL)animated;
		[Export ("dismissPopoverAnimated:")]
		void DismissPopover (bool animated);

		// -(void)presentPopoverFromBarButtonItem:(UIBarButtonItem *)item permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
		[Export ("presentPopoverFromBarButtonItem:permittedArrowDirections:animated:")]
		void PresentPopover (UIBarButtonItem item, UIPopoverArrowDirection arrowDirections, bool animated);

		// -(void)presentPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
		[Export ("presentPopoverFromRect:inView:permittedArrowDirections:animated:")]
		void PresentPopover (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated);

		// -(void)repositionPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections;
		[Export ("repositionPopoverFromRect:inView:permittedArrowDirections:")]
		void RepositionPopover (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections);

		// -(void)repositionPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
		[Export ("repositionPopoverFromRect:inView:permittedArrowDirections:animated:")]
		void RepositionPopover (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated);
	}

	interface IPopoverParentView {}

	// @protocol WEPopoverParentView
	[Protocol, Model]
	[BaseType(typeof (NSObject), Name = "WEPopoverParentView")]
	interface PopoverParentView
	{
		// @optional -(CGRect)displayAreaForPopover;
		[Export ("displayAreaForPopover")]
		CGRect DisplayAreaForPopover ();
	}


}
*/