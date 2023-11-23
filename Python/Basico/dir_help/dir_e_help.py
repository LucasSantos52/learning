"""
Utilitario python para auxiliar na programação

dir -> exibe atributos/Propriedades e funções/métodos disponíveis para determinado tipo de dado.

help -> apresenta como utilizar atributos/propriedades e funçoes/metodos para determinado tipo de dado.
"""

# dentro de um env - workon nome_do_env


""" EXEMPLO DIR
print(dir("test")) 

['__add__', '__class__', '__contains__', '__delattr__', '__dir__',
 '__doc__', '__eq__', '__format__', '__ge__', '__getattribute__', 
 '__getitem__', '__getnewargs__', '__getstate__', '__gt__', 
 '__hash__', '__init__', '__init_subclass__', '__iter__', 
 '__le__', '__len__', '__lt__', '__mod__', '__mul__', '__ne__', 
 '__new__', '__reduce__', '__reduce_ex__', '__repr__', '__rmod__', 
 '__rmul__', '__setattr__', '__sizeof__', '__str__', 
 '__subclasshook__', 'capitalize', 'casefold', 'center', 'count', 
 'encode', 'endswith', 'expandtabs', 'find', 'format', 
 'format_map', 'index', 'isalnum', 'isalpha', 'isascii', 
 'isdecimal', 'isdigit', 'isidentifier', 'islower', 'isnumeric', 
 'isprintable', 'isspace', 'istitle', 'isupper', 'join', 'ljust', 
 'lower', 'lstrip', 'maketrans', 'partition', 'removeprefix', 
 'removesuffix', 'replace', 'rfind', 'rindex', 'rjust', 
 'rpartition', 'rsplit', 'rstrip', 'split', 'splitlines', 
 'startswith', 'strip', 'swapcase', 'title', 'translate', 'upper', 
 'zfill']
"""

"""
print(help("test"))

Help on package test:

NAME
    test - # Dummy file to make this directory a package.

MODULE REFERENCE
    https://docs.python.org/3.12/library/test.html

    The following documentation is automatically generated from the Python
    source files.  It may be incomplete, incorrect or include features that
    are considered implementation detail and may vary between Python
    implementations.  When in doubt, consult the module reference at the
    location listed above.

PACKAGE CONTENTS
    __main__
    _test_atexit
    _test_eintr
    _test_embed_set_config
    _test_embed_structseq
    _test_multiprocessing
    _test_venv_multiprocessing
    _typed_dict_helper
    ann_module
    ann_module2
    ann_module3
    ann_module4
    ann_module5
    ann_module6
    ann_module7
    ann_module8
    audiotests
    audit-tests
    autotest
    bad_coding
    bad_coding2
    badsyntax_3131
    badsyntax_future10
    badsyntax_future3
    badsyntax_future4
    badsyntax_future5
    badsyntax_future6
    badsyntax_future7
    badsyntax_future8
    badsyntax_future9
    badsyntax_pep3120
    bisect_cmd
    coding20731
    curses_tests
    dataclass_module_1
    dataclass_module_1_str
    dataclass_module_2
    dataclass_module_2_str
    dataclass_textanno
    datetimetester
    dis_module
    doctest_aliases
    doctest_lineno
    double_const
    encoded_modules (package)
    final_a
    final_b
    fork_wait
    future_test1
    future_test2
    gdb_sample
    imp_dummy
    inspect_fodder
    inspect_fodder2
    inspect_stock_annotations
    inspect_stringized_annotations
    inspect_stringized_annotations_2
    leakers (package)
    libregrtest (package)
    list_tests
    lock_tests
    make_ssl_certs
    mapping_tests
    memory_watchdog
    mock_socket
    mod_generics_cache
    mp_fork_bomb
    mp_preload
    multibytecodec_support
    pickletester
    profilee
    pyclbr_input
    pydoc_mod
    pydocfodder
    pythoninfo
    re_tests
    regrtest
    relimport
    reperf
    sample_doctest
    sample_doctest_no_docstrings
    sample_doctest_no_doctests
    seq_tests
    shadowed_super
    signalinterproctester
    smtpd
    sortperf
    ssl_servers
    ssltests
    string_tests
    support (package)
    test___all__
    test___future__
    test__locale
    test__opcode
    test__osx_support
    test__xxinterpchannels
    test__xxsubinterpreters
    test_abc
    test_abstract_numbers
    test_aifc
    test_argparse
    test_array
    test_asdl_parser
    test_ast
    test_asyncgen
    test_asyncio (package)
    test_atexit
    test_audioop
    test_audit
    test_augassign
    test_base64
    test_baseexception
    test_bdb
    test_bigaddrspace
    test_bigmem
    test_binascii
    test_binop
    test_bisect
    test_bool
    test_buffer
    test_bufio
    test_builtin
    test_bytes
    test_bz2
    test_c_locale_coercion
    test_calendar
    test_call
    test_capi (package)
    test_cgi
    test_cgitb
    test_charmapcodec
    test_class
    test_clinic
    test_cmath
    test_cmd
    test_cmd_line
    test_cmd_line_script
    test_code
    test_code_module
    test_codeccallbacks
    test_codecencodings_cn
    test_codecencodings_hk
    test_codecencodings_iso2022
    test_codecencodings_jp
    test_codecencodings_kr
    test_codecencodings_tw
    test_codecmaps_cn
    test_codecmaps_hk
    test_codecmaps_jp
    test_codecmaps_kr
    test_codecmaps_tw
    test_codecs
    test_codeop
    test_collections
    test_colorsys
    test_compare
    test_compile
    test_compileall
    test_compiler_assemble
    test_compiler_codegen
    test_complex
    test_concurrent_futures (package)
    test_configparser
    test_contains
    test_context
    test_contextlib
    test_contextlib_async
    test_copy
    test_copyreg
    test_coroutines
    test_cppext (package)
    test_cprofile
    test_crashers
    test_crypt
    test_csv
    test_ctypes (package)
    test_curses
    test_dataclasses
    test_datetime
    test_dbm
    test_dbm_dumb
    test_dbm_gnu
    test_dbm_ndbm
    test_decimal
    test_decorators
    test_defaultdict
    test_deque
    test_descr
    test_descrtut
    test_devpoll
    test_dict
    test_dict_version
    test_dictcomps
    test_dictviews
    test_difflib
    test_dis
    test_doctest
    test_doctest2
    test_docxmlrpc
    test_dtrace
    test_dynamic
    test_dynamicclassattribute
    test_eintr
    test_email (package)
    test_embed
    test_ensurepip
    test_enum
    test_enumerate
    test_eof
    test_epoll
    test_errno
    test_except_star
    test_exception_group
    test_exception_hierarchy
    test_exception_variations
    test_exceptions
    test_extcall
    test_faulthandler
    test_fcntl
    test_file
    test_file_eintr
    test_filecmp
    test_fileinput
    test_fileio
    test_fileutils
    test_finalization
    test_float
    test_flufl
    test_fnmatch
    test_fork1
    test_format
    test_fractions
    test_frame
    test_frozen
    test_fstring
    test_ftplib
    test_funcattrs
    test_functools
    test_future
    test_future3
    test_future4
    test_future5
    test_gc
    test_gdb
    test_generator_stop
    test_generators
    test_genericalias
    test_genericclass
    test_genericpath
    test_genexps
    test_getopt
    test_getpass
    test_getpath
    test_gettext
    test_glob
    test_global
    test_grammar
    test_graphlib
    test_grp
    test_gzip
    test_hash
    test_hashlib
    test_heapq
    test_hmac
    test_html
    test_htmlparser
    test_http_cookiejar
    test_http_cookies
    test_httplib
    test_httpservers
    test_idle
    test_imaplib
    test_imghdr
    test_import (package)
    test_importlib (package)
    test_index
    test_inspect
    test_int
    test_int_literal
    test_interpreters
    test_io
    test_ioctl
    test_ipaddress
    test_isinstance
    test_iter
    test_iterlen
    test_itertools
    test_json (package)
    test_keyword
    test_keywordonlyarg
    test_kqueue
    test_largefile
    test_launcher
    test_lib2to3 (package)
    test_linecache
    test_list
    test_listcomps
    test_lltrace
    test_locale
    test_logging
    test_long
    test_longexp
    test_lzma
    test_mailbox
    test_mailcap
    test_marshal
    test_math
    test_math_property
    test_memoryio
    test_memoryview
    test_metaclass
    test_mimetypes
    test_minidom
    test_mmap
    test_module (package)
    test_modulefinder
    test_monitoring
    test_msilib
    test_multibytecodec
    test_multiprocessing_fork (package)
    test_multiprocessing_forkserver (package)
    test_multiprocessing_main_handling
    test_multiprocessing_spawn (package)
    test_named_expressions
    test_netrc
    test_nis
    test_nntplib
    test_ntpath
    test_numeric_tower
    test_opcache
    test_opcodes
    test_openpty
    test_operator
    test_optparse
    test_ordered_dict
    test_os
    test_ossaudiodev
    test_osx_env
    test_pathlib
    test_patma
    test_pdb
    test_peepholer
    test_peg_generator (package)
    test_pep646_syntax
    test_perf_profiler
    test_perfmaps
    test_pickle
    test_picklebuffer
    test_pickletools
    test_pipes
    test_pkg
    test_pkgutil
    test_platform
    test_plistlib
    test_poll
    test_popen
    test_poplib
    test_positional_only_arg
    test_posix
    test_posixpath
    test_pow
    test_pprint
    test_print
    test_profile
    test_property
    test_pstats
    test_pty
    test_pulldom
    test_pwd
    test_py_compile
    test_pyclbr
    test_pydoc
    test_pyexpat
    test_queue
    test_quopri
    test_raise
    test_random
    test_range
    test_re
    test_readline
    test_regrtest
    test_repl
    test_reprlib
    test_resource
    test_richcmp
    test_rlcompleter
    test_robotparser
    test_runpy
    test_sax
    test_sched
    test_scope
    test_script_helper
    test_secrets
    test_select
    test_selectors
    test_set
    test_setcomps
    test_shelve
    test_shlex
    test_shutil
    test_signal
    test_site
    test_slice
    test_smtplib
    test_smtpnet
    test_sndhdr
    test_socket
    test_socketserver
    test_sort
    test_source_encoding
    test_spwd
    test_sqlite3 (package)
    test_ssl
    test_stable_abi_ctypes
    test_startfile
    test_stat
    test_statistics
    test_strftime
    test_string
    test_string_literals
    test_stringprep
    test_strptime
    test_strtod
    test_struct
    test_structseq
    test_subclassinit
    test_subprocess
    test_sunau
    test_sundry
    test_super
    test_support
    test_symtable
    test_syntax
    test_sys
    test_sys_setprofile
    test_sys_settrace
    test_sysconfig
    test_syslog
    test_tabnanny
    test_tarfile
    test_tcl
    test_telnetlib
    test_tempfile
    test_textwrap
    test_thread
    test_threadedtempfile
    test_threading
    test_threading_local
    test_threadsignals
    test_time
    test_timeit
    test_timeout
    test_tix
    test_tkinter (package)
    test_tokenize
    test_tomllib (package)
    test_tools (package)
    test_trace
    test_traceback
    test_tracemalloc
    test_ttk (package)
    test_ttk_textonly
    test_tuple
    test_turtle
    test_type_aliases
    test_type_annotations
    test_type_cache
    test_type_comments
    test_type_params
    test_typechecks
    test_types
    test_typing
    test_ucn
    test_unary
    test_unicode
    test_unicode_file
    test_unicode_file_functions
    test_unicode_identifiers
    test_unicodedata
    test_unittest (package)
    test_univnewlines
    test_unpack
    test_unpack_ex
    test_unparse
    test_urllib
    test_urllib2
    test_urllib2_localnet
    test_urllib2net
    test_urllib_response
    test_urllibnet
    test_urlparse
    test_userdict
    test_userlist
    test_userstring
    test_utf8_mode
    test_utf8source
    test_uu
    test_uuid
    test_venv
    test_wait3
    test_wait4
    test_warnings (package)
    test_wave
    test_weakref
    test_weakset
    test_webbrowser
    test_winconsoleio
    test_winreg
    test_winsound
    test_with
    test_wmi
    test_wsgiref
    test_xdrlib
    test_xml_dom_minicompat
    test_xml_etree
    test_xml_etree_c
    test_xmlrpc
    test_xmlrpc_net
    test_xxlimited
    test_xxtestfuzz
    test_yield_from
    test_zipapp
    test_zipfile (package)
    test_zipfile64
    test_zipimport
    test_zipimport_support
    test_zlib
    test_zoneinfo (package)
    testcodec
    tf_inherit_check
    time_hashlib
    tracedmodules (package)
    typinganndata (package)
    win_console_handler
    xmltests
"""

"""
print(help("test".upper))

Help on built-in function upper:

upper() method of builtins.str instance
    Return a copy of the string converted to uppercase.

"""

"""
print("test".upper())
TEST
"""