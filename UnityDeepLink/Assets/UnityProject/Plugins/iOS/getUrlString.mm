#import <Foundation/Foundation.h>
#import "UnityAppController.h"

// static な変数保持用

@interface IntentParameter : NSObject
+ (NSString*)getUrlString;
+ (void)setUrlString:(NSString*)str;
@end

@implementation IntentParameter
static id urlString = @"";
+(NSString*)getUrlString{
    return urlString;
}
+(void)setUrlString:(NSString*)str{
    urlString = [str copy];
}
@end


// openURLをフックする処理

@interface UrlHandlerAppController : UnityAppController
@end

@implementation UrlHandlerAppController
- (BOOL)application:(UIApplication *)application openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey, id> *)options {
    
    [IntentParameter setUrlString:[url absoluteString]];
    
    return YES;
}
@end

IMPL_APP_CONTROLLER_SUBCLASS(UrlHandlerAppController);


// APIの定義

extern "C"{ const char* getUrlString(); }

const char* getUrlString(){
    NSString *string = [IntentParameter getUrlString];
    const char *str = [string UTF8String];
    
    char* retStr = (char *)malloc(strlen(str) + 1);
    strcpy(retStr, str);
    return retStr;
}
