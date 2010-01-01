/*!  \file kfbxreader.h
 */

#ifndef FBXFILESDK_KFBXIO_KFBXREADER_H
#define FBXFILESDK_KFBXIO_KFBXREADER_H

/**************************************************************************************

 Copyright � 2001 - 2008 Autodesk, Inc. and/or its licensors.
 All Rights Reserved.

 The coded instructions, statements, computer programs, and/or related material 
 (collectively the "Data") in these files contain unpublished information 
 proprietary to Autodesk, Inc. and/or its licensors, which is protected by 
 Canada and United States of America federal copyright law and by international 
 treaties. 
 
 The Data may not be disclosed or distributed to third parties, in whole or in
 part, without the prior written consent of Autodesk, Inc. ("Autodesk").

 THE DATA IS PROVIDED "AS IS" AND WITHOUT WARRANTY.
 ALL WARRANTIES ARE EXPRESSLY EXCLUDED AND DISCLAIMED. AUTODESK MAKES NO
 WARRANTY OF ANY KIND WITH RESPECT TO THE DATA, EXPRESS, IMPLIED OR ARISING
 BY CUSTOM OR TRADE USAGE, AND DISCLAIMS ANY IMPLIED WARRANTIES OF TITLE, 
 NON-INFRINGEMENT, MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE OR USE. 
 WITHOUT LIMITING THE FOREGOING, AUTODESK DOES NOT WARRANT THAT THE OPERATION
 OF THE DATA WILL BE UNINTERRUPTED OR ERROR FREE. 
 
 IN NO EVENT SHALL AUTODESK, ITS AFFILIATES, PARENT COMPANIES, LICENSORS
 OR SUPPLIERS ("AUTODESK GROUP") BE LIABLE FOR ANY LOSSES, DAMAGES OR EXPENSES
 OF ANY KIND (INCLUDING WITHOUT LIMITATION PUNITIVE OR MULTIPLE DAMAGES OR OTHER
 SPECIAL, DIRECT, INDIRECT, EXEMPLARY, INCIDENTAL, LOSS OF PROFITS, REVENUE
 OR DATA, COST OF COVER OR CONSEQUENTIAL LOSSES OR DAMAGES OF ANY KIND),
 HOWEVER CAUSED, AND REGARDLESS OF THE THEORY OF LIABILITY, WHETHER DERIVED
 FROM CONTRACT, TORT (INCLUDING, BUT NOT LIMITED TO, NEGLIGENCE), OR OTHERWISE,
 ARISING OUT OF OR RELATING TO THE DATA OR ITS USE OR ANY OTHER PERFORMANCE,
 WHETHER OR NOT AUTODESK HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH LOSS
 OR DAMAGE. 

**************************************************************************************/

#include <fbxfilesdk/components/kbaselib/kaydaradef_h.h>
#include <fbxfilesdk/components/kbaselib/klib/kerror.h>

#include <fbxfilesdk/components/kbaselib/kbaselib_forward.h>
#include <fbxfilesdk/components/kfcurve/kfcurve_forward.h>

#include <fbxfilesdk/fbxfilesdk_nsbegin.h>

class KFbxDocument;
class KFbxNode;
class KFbxSdkManager;
class KFbxImporter;
class KFbxStreamOptions;
class KFbxIOSettings;
class KFbxAxisSystem;
class KFbxSystemUnit;
class KFbxStatistics;
class KFile;
class KFbxObject;
class KFbxScene;

struct KFbxReaderData;

class KFBX_DLL KFbxReader
{
public:
    KFbxReader(KFbxSdkManager& pManager, int pID);
    virtual ~KFbxReader();

    //! Error codes
    typedef enum
    {
        eFILE_CORRUPTED,
        eFILE_VERSION_NOT_SUPPORTED_YET,
        eFILE_VERSION_NOT_SUPPORTED_ANYMORE,
        eFILE_NOT_OPENED,
        eFILE_NOT_CREATED,
        eWRONG_PASSWORD,
        eSTREAM_OPTIONS_NOT_SET,
        eINVALID_DOCUMENT_HANDLE,
        eDOCUMENT_NOT_SUPPORTED,
        eUNRESOLVED_EXTERNAL_REFERENCES, // this is a warning
        eUNIDENTIFIED_ERROR,
        eERROR_COUNT
    } EError;

    enum KInfoRequest {
        eInfoExtension, // return a null terminated char const* const*
        eInfoDescriptions, // return a null terminated char const* const*
        eReserved1 = 0xFBFB,
    };

    enum EFileOpenSpecialFlags {
		ParseForGlobalSettings = 1, 
		ParseForStatistics = 2
	};

    typedef KFbxReader*			(*CreateFuncType)(KFbxSdkManager& pManager, KFbxImporter& pImporter, int pSubID, int pPluginID);
    typedef void				(*IOSettingsFillerFuncType)(KFbxIOSettings& pIOS);
    typedef void*				(*GetInfoFuncType)(KInfoRequest pRequest, int pReaderTypeId);

	virtual void				GetVersion(int& pMajor, int& pMinor, int& pRevision){ pMajor = pMinor = pRevision = 0; }
    virtual bool				FileOpen(char* pFileName) = 0;
    virtual bool				FileOpen(KFile * pFile);
    virtual bool				FileClose() = 0;
    virtual bool				IsFileOpen() = 0;

    virtual KFbxStreamOptions*	GetReadOptions(bool pParseFileAsNeeded = true) = 0;
    virtual bool				Read(KFbxDocument* pDocument, KFbxStreamOptions* pStreamOptions) = 0;

	virtual void				PluginReadSettings(KFbxObject& pSettings){}

    virtual bool				FileOpen(char* pFileName, EFileOpenSpecialFlags pFlags){ return FileOpen(pFileName); }
    virtual bool				GetAxisInfo(KFbxAxisSystem* pAxisSystem, KFbxSystemUnit* pSystemUnits){ return false; }
    virtual bool				GetStatistics(KFbxStatistics* pStats){ return false; }
	bool						GetDefaultRenderResolution(KString& pCamName, KString& pResolutionMode, double& pW, double& pH);
	bool						IsGenuine();

    KError&						GetError();
    EError						GetLastErrorID() const;
    const char*					GetLastErrorString() const;
    void						GetMessage(KString& pMessage) const;
    KString&					GetMessage();
    void						ClearMessage();

protected:
	void						SetDefaultRenderResolution(const char* pCamName, const char* pResolutionMode, double pW, double pH);
	void						InvalidateDefaultRenderResolution();

	void						PluginsReadBegin(KFbxScene& pScene);
	void						PluginsRead(char* pName, char* pVersion);
	void						PluginsReadEnd(KFbxScene& pScene);

    KFbxReader&					operator=(KFbxReader const&) { return *this; }
    virtual bool				CheckDuplicateNodeNames(KFbxNode* pRootNode, KString& pDuplicateNodeNameList);

    KFbxSdkManager&				mManager;

private:
    KError						mError;
    KString						mMessage;
	KFbxReaderData*				mData;
	int							mInternalID;
};

#include <fbxfilesdk/fbxfilesdk_nsend.h>

#endif // FBXFILESDK_KFBXIO_KFBXREADER_H


