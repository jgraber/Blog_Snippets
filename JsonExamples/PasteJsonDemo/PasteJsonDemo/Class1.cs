using System;

namespace PasteJsonDemo
{

    public class Rootobject
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Bookmark_Timeline bookmark_timeline { get; set; }
    }

    public class Bookmark_Timeline
    {
        public Timeline timeline { get; set; }
    }

    public class Timeline
    {
        public Instruction[] instructions { get; set; }
        public Responseobjects responseObjects { get; set; }
    }

    public class Responseobjects
    {
        public object[] feedbackActions { get; set; }
        public object[] immediateReactions { get; set; }
    }

    public class Instruction
    {
        public string type { get; set; }
        public Entry[] entries { get; set; }
    }

    public class Entry
    {
        public string entryId { get; set; }
        public string sortIndex { get; set; }
        public Content content { get; set; }
    }

    public class Content
    {
        public string entryType { get; set; }
        public Itemcontent itemContent { get; set; }
        public string value { get; set; }
        public string cursorType { get; set; }
        public bool stopOnEmptyResponse { get; set; }
    }

    public class Itemcontent
    {
        public string itemType { get; set; }
        public Tweet_Results tweet_results { get; set; }
        public string tweetDisplayType { get; set; }
    }

    public class Tweet_Results
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public string __typename { get; set; }
        public string rest_id { get; set; }
        public Core core { get; set; }
        public Legacy1 legacy { get; set; }
        public Card card { get; set; }
        public Quoted_Status_Result quoted_status_result { get; set; }
    }

    public class Core
    {
        public User_Results user_results { get; set; }
    }

    public class User_Results
    {
        public Result1 result { get; set; }
    }

    public class Result1
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string rest_id { get; set; }
        public Affiliates_Highlighted_Label affiliates_highlighted_label { get; set; }
        public bool has_nft_avatar { get; set; }
        public Legacy legacy { get; set; }
        public bool super_follow_eligible { get; set; }
        public bool super_followed_by { get; set; }
        public bool super_following { get; set; }
        public Professional professional { get; set; }
    }

    public class Affiliates_Highlighted_Label
    {
    }

    public class Legacy
    {
        public bool blocked_by { get; set; }
        public bool blocking { get; set; }
        public bool can_dm { get; set; }
        public bool can_media_tag { get; set; }
        public string created_at { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public string description { get; set; }
        public Entities entities { get; set; }
        public int fast_followers_count { get; set; }
        public int favourites_count { get; set; }
        public bool follow_request_sent { get; set; }
        public bool followed_by { get; set; }
        public int followers_count { get; set; }
        public bool following { get; set; }
        public int friends_count { get; set; }
        public bool has_custom_timelines { get; set; }
        public bool is_translator { get; set; }
        public int listed_count { get; set; }
        public string location { get; set; }
        public int media_count { get; set; }
        public bool muting { get; set; }
        public string name { get; set; }
        public int normal_followers_count { get; set; }
        public bool notifications { get; set; }
        public string[] pinned_tweet_ids_str { get; set; }
        public Profile_Banner_Extensions profile_banner_extensions { get; set; }
        public string profile_banner_url { get; set; }
        public Profile_Image_Extensions profile_image_extensions { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_interstitial_type { get; set; }
        public bool _protected { get; set; }
        public string screen_name { get; set; }
        public int statuses_count { get; set; }
        public string translator_type { get; set; }
        public string url { get; set; }
        public bool verified { get; set; }
        public bool want_retweets { get; set; }
        public object[] withheld_in_countries { get; set; }
    }

    public class Entities
    {
        public Description description { get; set; }
        public Url1 url { get; set; }
    }

    public class Description
    {
        public Url[] urls { get; set; }
    }

    public class Url
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Url1
    {
        public Url2[] urls { get; set; }
    }

    public class Url2
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Profile_Banner_Extensions
    {
        public Mediacolor mediaColor { get; set; }
    }

    public class Mediacolor
    {
        public R r { get; set; }
    }

    public class R
    {
        public Ok ok { get; set; }
    }

    public class Ok
    {
        public Palette[] palette { get; set; }
    }

    public class Palette
    {
        public float percentage { get; set; }
        public Rgb rgb { get; set; }
    }

    public class Rgb
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Profile_Image_Extensions
    {
        public Mediacolor1 mediaColor { get; set; }
    }

    public class Mediacolor1
    {
        public R1 r { get; set; }
    }

    public class R1
    {
        public Ok1 ok { get; set; }
    }

    public class Ok1
    {
        public Palette1[] palette { get; set; }
    }

    public class Palette1
    {
        public float percentage { get; set; }
        public Rgb1 rgb { get; set; }
    }

    public class Rgb1
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Professional
    {
        public string rest_id { get; set; }
        public string professional_type { get; set; }
        public Category[] category { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Legacy1
    {
        public string created_at { get; set; }
        public string conversation_id_str { get; set; }
        public int[] display_text_range { get; set; }
        public Entities1 entities { get; set; }
        public int favorite_count { get; set; }
        public bool favorited { get; set; }
        public string full_text { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public bool is_quote_status { get; set; }
        public string lang { get; set; }
        public int reply_count { get; set; }
        public int retweet_count { get; set; }
        public bool retweeted { get; set; }
        public string source { get; set; }
        public string user_id_str { get; set; }
        public string id_str { get; set; }
        public Self_Thread self_thread { get; set; }
        public bool possibly_sensitive { get; set; }
        public bool possibly_sensitive_editable { get; set; }
        public string quoted_status_id_str { get; set; }
        public Quoted_Status_Permalink quoted_status_permalink { get; set; }
        public Extended_Entities extended_entities { get; set; }
    }

    public class Entities1
    {
        public User_Mentions[] user_mentions { get; set; }
        public Url3[] urls { get; set; }
        public Hashtag[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public Medium[] media { get; set; }
    }

    public class User_Mentions
    {
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public int[] indices { get; set; }
    }

    public class Url3
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Hashtag
    {
        public int[] indices { get; set; }
        public string text { get; set; }
    }

    public class Medium
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string id_str { get; set; }
        public int[] indices { get; set; }
        public string media_url_https { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public Features features { get; set; }
        public Sizes sizes { get; set; }
        public Original_Info original_info { get; set; }
    }

    public class Features
    {
        public Large large { get; set; }
        public Medium1 medium { get; set; }
        public Small small { get; set; }
        public Orig orig { get; set; }
    }

    public class Large
    {
        public Face[] faces { get; set; }
    }

    public class Face
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Medium1
    {
        public Face1[] faces { get; set; }
    }

    public class Face1
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Small
    {
        public Face2[] faces { get; set; }
    }

    public class Face2
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Orig
    {
        public Face3[] faces { get; set; }
    }

    public class Face3
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Sizes
    {
        public Large1 large { get; set; }
        public Medium2 medium { get; set; }
        public Small1 small { get; set; }
        public Thumb thumb { get; set; }
    }

    public class Large1
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Medium2
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Small1
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Thumb
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Original_Info
    {
        public int height { get; set; }
        public int width { get; set; }
        public Focus_Rects[] focus_rects { get; set; }
    }

    public class Focus_Rects
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Self_Thread
    {
        public string id_str { get; set; }
    }

    public class Quoted_Status_Permalink
    {
        public string url { get; set; }
        public string expanded { get; set; }
        public string display { get; set; }
    }

    public class Extended_Entities
    {
        public Medium3[] media { get; set; }
    }

    public class Medium3
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string id_str { get; set; }
        public int[] indices { get; set; }
        public string media_key { get; set; }
        public string media_url_https { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public Ext_Media_Color ext_media_color { get; set; }
        public Ext_Media_Availability ext_media_availability { get; set; }
        public Features1 features { get; set; }
        public Sizes1 sizes { get; set; }
        public Original_Info1 original_info { get; set; }
    }

    public class Ext_Media_Color
    {
        public Palette2[] palette { get; set; }
    }

    public class Palette2
    {
        public float percentage { get; set; }
        public Rgb2 rgb { get; set; }
    }

    public class Rgb2
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Ext_Media_Availability
    {
        public string status { get; set; }
    }

    public class Features1
    {
        public Large2 large { get; set; }
        public Medium4 medium { get; set; }
        public Small2 small { get; set; }
        public Orig1 orig { get; set; }
    }

    public class Large2
    {
        public Face4[] faces { get; set; }
    }

    public class Face4
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Medium4
    {
        public Face5[] faces { get; set; }
    }

    public class Face5
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Small2
    {
        public Face6[] faces { get; set; }
    }

    public class Face6
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Orig1
    {
        public Face7[] faces { get; set; }
    }

    public class Face7
    {
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Sizes1
    {
        public Large3 large { get; set; }
        public Medium5 medium { get; set; }
        public Small3 small { get; set; }
        public Thumb1 thumb { get; set; }
    }

    public class Large3
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Medium5
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Small3
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Thumb1
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Original_Info1
    {
        public int height { get; set; }
        public int width { get; set; }
        public Focus_Rects1[] focus_rects { get; set; }
    }

    public class Focus_Rects1
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Card
    {
        public string rest_id { get; set; }
        public Legacy2 legacy { get; set; }
    }

    public class Legacy2
    {
        public Binding_Values[] binding_values { get; set; }
        public Card_Platform card_platform { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public User_Refs[] user_refs { get; set; }
    }

    public class Card_Platform
    {
        public Platform platform { get; set; }
    }

    public class Platform
    {
        public Audience audience { get; set; }
        public Device device { get; set; }
    }

    public class Audience
    {
        public string name { get; set; }
    }

    public class Device
    {
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Binding_Values
    {
        public string key { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public Image_Value image_value { get; set; }
        public string type { get; set; }
        public string string_value { get; set; }
        public string scribe_key { get; set; }
        public User_Value user_value { get; set; }
        public Image_Color_Value image_color_value { get; set; }
    }

    public class Image_Value
    {
        public int height { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }

    public class User_Value
    {
        public string id_str { get; set; }
        public object[] path { get; set; }
    }

    public class Image_Color_Value
    {
        public Palette3[] palette { get; set; }
    }

    public class Palette3
    {
        public Rgb3 rgb { get; set; }
        public float percentage { get; set; }
    }

    public class Rgb3
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class User_Refs
    {
        public string id { get; set; }
        public string rest_id { get; set; }
        public Affiliates_Highlighted_Label1 affiliates_highlighted_label { get; set; }
        public bool has_nft_avatar { get; set; }
        public Legacy3 legacy { get; set; }
        public bool super_follow_eligible { get; set; }
        public bool super_followed_by { get; set; }
        public bool super_following { get; set; }
        public Professional1 professional { get; set; }
    }

    public class Affiliates_Highlighted_Label1
    {
    }

    public class Legacy3
    {
        public bool blocked_by { get; set; }
        public bool blocking { get; set; }
        public bool can_dm { get; set; }
        public bool can_media_tag { get; set; }
        public string created_at { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public string description { get; set; }
        public Entities2 entities { get; set; }
        public int fast_followers_count { get; set; }
        public int favourites_count { get; set; }
        public bool follow_request_sent { get; set; }
        public bool followed_by { get; set; }
        public int followers_count { get; set; }
        public bool following { get; set; }
        public int friends_count { get; set; }
        public bool has_custom_timelines { get; set; }
        public bool is_translator { get; set; }
        public int listed_count { get; set; }
        public string location { get; set; }
        public int media_count { get; set; }
        public bool muting { get; set; }
        public string name { get; set; }
        public int normal_followers_count { get; set; }
        public bool notifications { get; set; }
        public string[] pinned_tweet_ids_str { get; set; }
        public Profile_Banner_Extensions1 profile_banner_extensions { get; set; }
        public string profile_banner_url { get; set; }
        public Profile_Image_Extensions1 profile_image_extensions { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_interstitial_type { get; set; }
        public bool _protected { get; set; }
        public string screen_name { get; set; }
        public int statuses_count { get; set; }
        public string translator_type { get; set; }
        public string url { get; set; }
        public bool verified { get; set; }
        public bool want_retweets { get; set; }
        public object[] withheld_in_countries { get; set; }
    }

    public class Entities2
    {
        public Description1 description { get; set; }
        public Url5 url { get; set; }
    }

    public class Description1
    {
        public Url4[] urls { get; set; }
    }

    public class Url4
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Url5
    {
        public Url6[] urls { get; set; }
    }

    public class Url6
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Profile_Banner_Extensions1
    {
        public Mediacolor2 mediaColor { get; set; }
    }

    public class Mediacolor2
    {
        public R2 r { get; set; }
    }

    public class R2
    {
        public Ok2 ok { get; set; }
    }

    public class Ok2
    {
        public Palette4[] palette { get; set; }
    }

    public class Palette4
    {
        public float percentage { get; set; }
        public Rgb4 rgb { get; set; }
    }

    public class Rgb4
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Profile_Image_Extensions1
    {
        public Mediacolor3 mediaColor { get; set; }
    }

    public class Mediacolor3
    {
        public R3 r { get; set; }
    }

    public class R3
    {
        public Ok3 ok { get; set; }
    }

    public class Ok3
    {
        public Palette5[] palette { get; set; }
    }

    public class Palette5
    {
        public float percentage { get; set; }
        public Rgb5 rgb { get; set; }
    }

    public class Rgb5
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Professional1
    {
        public string rest_id { get; set; }
        public string professional_type { get; set; }
        public object[] category { get; set; }
    }

    public class Quoted_Status_Result
    {
        public Result2 result { get; set; }
    }

    public class Result2
    {
        public string __typename { get; set; }
        public string rest_id { get; set; }
        public Core1 core { get; set; }
        public Card1 card { get; set; }
        public Legacy7 legacy { get; set; }
    }

    public class Core1
    {
        public User_Results1 user_results { get; set; }
    }

    public class User_Results1
    {
        public Result3 result { get; set; }
    }

    public class Result3
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string rest_id { get; set; }
        public Affiliates_Highlighted_Label2 affiliates_highlighted_label { get; set; }
        public bool has_nft_avatar { get; set; }
        public Legacy4 legacy { get; set; }
        public bool super_follow_eligible { get; set; }
        public bool super_followed_by { get; set; }
        public bool super_following { get; set; }
    }

    public class Affiliates_Highlighted_Label2
    {
    }

    public class Legacy4
    {
        public bool blocked_by { get; set; }
        public bool blocking { get; set; }
        public bool can_dm { get; set; }
        public bool can_media_tag { get; set; }
        public string created_at { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public string description { get; set; }
        public Entities3 entities { get; set; }
        public int fast_followers_count { get; set; }
        public int favourites_count { get; set; }
        public bool follow_request_sent { get; set; }
        public bool followed_by { get; set; }
        public int followers_count { get; set; }
        public bool following { get; set; }
        public int friends_count { get; set; }
        public bool has_custom_timelines { get; set; }
        public bool is_translator { get; set; }
        public int listed_count { get; set; }
        public string location { get; set; }
        public int media_count { get; set; }
        public bool muting { get; set; }
        public string name { get; set; }
        public int normal_followers_count { get; set; }
        public bool notifications { get; set; }
        public string[] pinned_tweet_ids_str { get; set; }
        public Profile_Banner_Extensions2 profile_banner_extensions { get; set; }
        public string profile_banner_url { get; set; }
        public Profile_Image_Extensions2 profile_image_extensions { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_interstitial_type { get; set; }
        public bool _protected { get; set; }
        public string screen_name { get; set; }
        public int statuses_count { get; set; }
        public string translator_type { get; set; }
        public bool verified { get; set; }
        public bool want_retweets { get; set; }
        public object[] withheld_in_countries { get; set; }
        public string url { get; set; }
    }

    public class Entities3
    {
        public Description2 description { get; set; }
        public Url7 url { get; set; }
    }

    public class Description2
    {
        public object[] urls { get; set; }
    }

    public class Url7
    {
        public Url8[] urls { get; set; }
    }

    public class Url8
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Profile_Banner_Extensions2
    {
        public Mediacolor4 mediaColor { get; set; }
    }

    public class Mediacolor4
    {
        public R4 r { get; set; }
    }

    public class R4
    {
        public Ok4 ok { get; set; }
    }

    public class Ok4
    {
        public Palette6[] palette { get; set; }
    }

    public class Palette6
    {
        public float percentage { get; set; }
        public Rgb6 rgb { get; set; }
    }

    public class Rgb6
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Profile_Image_Extensions2
    {
        public Mediacolor5 mediaColor { get; set; }
    }

    public class Mediacolor5
    {
        public R5 r { get; set; }
    }

    public class R5
    {
        public Ok5 ok { get; set; }
    }

    public class Ok5
    {
        public Palette7[] palette { get; set; }
    }

    public class Palette7
    {
        public float percentage { get; set; }
        public Rgb7 rgb { get; set; }
    }

    public class Rgb7
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Card1
    {
        public string rest_id { get; set; }
        public Legacy5 legacy { get; set; }
    }

    public class Legacy5
    {
        public Binding_Values1[] binding_values { get; set; }
        public Card_Platform1 card_platform { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public User_Refs1[] user_refs { get; set; }
    }

    public class Card_Platform1
    {
        public Platform1 platform { get; set; }
    }

    public class Platform1
    {
        public Audience1 audience { get; set; }
        public Device1 device { get; set; }
    }

    public class Audience1
    {
        public string name { get; set; }
    }

    public class Device1
    {
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Binding_Values1
    {
        public string key { get; set; }
        public Value1 value { get; set; }
    }

    public class Value1
    {
        public Image_Value1 image_value { get; set; }
        public string type { get; set; }
        public string string_value { get; set; }
        public string scribe_key { get; set; }
        public User_Value1 user_value { get; set; }
        public Image_Color_Value1 image_color_value { get; set; }
    }

    public class Image_Value1
    {
        public int height { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }

    public class User_Value1
    {
        public string id_str { get; set; }
        public object[] path { get; set; }
    }

    public class Image_Color_Value1
    {
        public Palette8[] palette { get; set; }
    }

    public class Palette8
    {
        public Rgb8 rgb { get; set; }
        public float percentage { get; set; }
    }

    public class Rgb8
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class User_Refs1
    {
        public string id { get; set; }
        public string rest_id { get; set; }
        public Affiliates_Highlighted_Label3 affiliates_highlighted_label { get; set; }
        public bool has_nft_avatar { get; set; }
        public Legacy6 legacy { get; set; }
        public bool super_follow_eligible { get; set; }
        public bool super_followed_by { get; set; }
        public bool super_following { get; set; }
    }

    public class Affiliates_Highlighted_Label3
    {
    }

    public class Legacy6
    {
        public bool blocked_by { get; set; }
        public bool blocking { get; set; }
        public bool can_dm { get; set; }
        public bool can_media_tag { get; set; }
        public string created_at { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public string description { get; set; }
        public Entities4 entities { get; set; }
        public int fast_followers_count { get; set; }
        public int favourites_count { get; set; }
        public bool follow_request_sent { get; set; }
        public bool followed_by { get; set; }
        public int followers_count { get; set; }
        public bool following { get; set; }
        public int friends_count { get; set; }
        public bool has_custom_timelines { get; set; }
        public bool is_translator { get; set; }
        public int listed_count { get; set; }
        public string location { get; set; }
        public int media_count { get; set; }
        public bool muting { get; set; }
        public string name { get; set; }
        public int normal_followers_count { get; set; }
        public bool notifications { get; set; }
        public string[] pinned_tweet_ids_str { get; set; }
        public Profile_Banner_Extensions3 profile_banner_extensions { get; set; }
        public string profile_banner_url { get; set; }
        public Profile_Image_Extensions3 profile_image_extensions { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_interstitial_type { get; set; }
        public bool _protected { get; set; }
        public string screen_name { get; set; }
        public int statuses_count { get; set; }
        public string translator_type { get; set; }
        public string url { get; set; }
        public bool verified { get; set; }
        public bool want_retweets { get; set; }
        public object[] withheld_in_countries { get; set; }
    }

    public class Entities4
    {
        public Description3 description { get; set; }
        public Url9 url { get; set; }
    }

    public class Description3
    {
        public object[] urls { get; set; }
    }

    public class Url9
    {
        public Url10[] urls { get; set; }
    }

    public class Url10
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Profile_Banner_Extensions3
    {
        public Mediacolor6 mediaColor { get; set; }
    }

    public class Mediacolor6
    {
        public R6 r { get; set; }
    }

    public class R6
    {
        public Ok6 ok { get; set; }
    }

    public class Ok6
    {
        public Palette9[] palette { get; set; }
    }

    public class Palette9
    {
        public float percentage { get; set; }
        public Rgb9 rgb { get; set; }
    }

    public class Rgb9
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Profile_Image_Extensions3
    {
        public Mediacolor7 mediaColor { get; set; }
    }

    public class Mediacolor7
    {
        public R7 r { get; set; }
    }

    public class R7
    {
        public Ok7 ok { get; set; }
    }

    public class Ok7
    {
        public Palette10[] palette { get; set; }
    }

    public class Palette10
    {
        public float percentage { get; set; }
        public Rgb10 rgb { get; set; }
    }

    public class Rgb10
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Legacy7
    {
        public string created_at { get; set; }
        public string conversation_id_str { get; set; }
        public int[] display_text_range { get; set; }
        public Entities5 entities { get; set; }
        public int favorite_count { get; set; }
        public bool favorited { get; set; }
        public string full_text { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public bool is_quote_status { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public bool possibly_sensitive_editable { get; set; }
        public int reply_count { get; set; }
        public int retweet_count { get; set; }
        public bool retweeted { get; set; }
        public string source { get; set; }
        public string user_id_str { get; set; }
        public string id_str { get; set; }
        public Self_Thread1 self_thread { get; set; }
        public Extended_Entities1 extended_entities { get; set; }
    }

    public class Entities5
    {
        public User_Mentions1[] user_mentions { get; set; }
        public Url11[] urls { get; set; }
        public object[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public Medium6[] media { get; set; }
    }

    public class User_Mentions1
    {
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public int[] indices { get; set; }
    }

    public class Url11
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
    }

    public class Medium6
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string id_str { get; set; }
        public int[] indices { get; set; }
        public string media_url_https { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public Features2 features { get; set; }
        public Sizes2 sizes { get; set; }
        public Original_Info2 original_info { get; set; }
    }

    public class Features2
    {
        public Large4 large { get; set; }
        public Medium7 medium { get; set; }
        public Small4 small { get; set; }
        public Orig2 orig { get; set; }
    }

    public class Large4
    {
        public object[] faces { get; set; }
    }

    public class Medium7
    {
        public object[] faces { get; set; }
    }

    public class Small4
    {
        public object[] faces { get; set; }
    }

    public class Orig2
    {
        public object[] faces { get; set; }
    }

    public class Sizes2
    {
        public Large5 large { get; set; }
        public Medium8 medium { get; set; }
        public Small5 small { get; set; }
        public Thumb2 thumb { get; set; }
    }

    public class Large5
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Medium8
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Small5
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Thumb2
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Original_Info2
    {
        public int height { get; set; }
        public int width { get; set; }
        public Focus_Rects2[] focus_rects { get; set; }
    }

    public class Focus_Rects2
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Self_Thread1
    {
        public string id_str { get; set; }
    }

    public class Extended_Entities1
    {
        public Medium9[] media { get; set; }
    }

    public class Medium9
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string id_str { get; set; }
        public int[] indices { get; set; }
        public string media_key { get; set; }
        public string media_url_https { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public Ext_Media_Color1 ext_media_color { get; set; }
        public Ext_Media_Availability1 ext_media_availability { get; set; }
        public Features3 features { get; set; }
        public Sizes3 sizes { get; set; }
        public Original_Info3 original_info { get; set; }
    }

    public class Ext_Media_Color1
    {
        public Palette11[] palette { get; set; }
    }

    public class Palette11
    {
        public float percentage { get; set; }
        public Rgb11 rgb { get; set; }
    }

    public class Rgb11
    {
        public int blue { get; set; }
        public int green { get; set; }
        public int red { get; set; }
    }

    public class Ext_Media_Availability1
    {
        public string status { get; set; }
    }

    public class Features3
    {
        public Large6 large { get; set; }
        public Medium10 medium { get; set; }
        public Small6 small { get; set; }
        public Orig3 orig { get; set; }
    }

    public class Large6
    {
        public object[] faces { get; set; }
    }

    public class Medium10
    {
        public object[] faces { get; set; }
    }

    public class Small6
    {
        public object[] faces { get; set; }
    }

    public class Orig3
    {
        public object[] faces { get; set; }
    }

    public class Sizes3
    {
        public Large7 large { get; set; }
        public Medium11 medium { get; set; }
        public Small7 small { get; set; }
        public Thumb3 thumb { get; set; }
    }

    public class Large7
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Medium11
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Small7
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Thumb3
    {
        public int h { get; set; }
        public int w { get; set; }
        public string resize { get; set; }
    }

    public class Original_Info3
    {
        public int height { get; set; }
        public int width { get; set; }
        public Focus_Rects3[] focus_rects { get; set; }
    }

    public class Focus_Rects3
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

}
